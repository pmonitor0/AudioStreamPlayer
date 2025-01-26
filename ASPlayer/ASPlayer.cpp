#include "pch.h"

#include "ASplayer.h"



#include <Windows.h>
#include <iostream>
#include <string>
#include <sstream>
#include <vlc\vlc.h>
#include <vlc\libvlc_media_player.h>

libvlc_instance_t* vlc;
libvlc_media_t* media;
libvlc_media_player_t* player = NULL;

libvlc_media_t* mediaRec;
libvlc_media_player_t* playerRec = NULL;

typedef void (*BufferCallback)(float buffer);
BufferCallback bufferCallback = nullptr;

typedef void (*PlayingCallback)();
PlayingCallback playingCallback = nullptr;

__declspec(dllexport) int Init()
{
    vlc = libvlc_new(0, nullptr);
    if (!vlc) {
        std::cout << "LibVLC inicializálás sikertelen: " << libvlc_errmsg() << std::endl;
        return 1;
    }

    return 0;
}

__declspec(dllexport) void StartRecorder(char* url)
{
    mediaRec = libvlc_media_new_location(vlc, url);
    playerRec = libvlc_media_player_new_from_media(mediaRec);
    libvlc_media_add_option(mediaRec, "sout=file/mp3:output.mp3");
    libvlc_media_player_play(playerRec);
}

__declspec(dllexport) void StopRecorder()
{
    libvlc_media_player_stop(playerRec);
    libvlc_media_release(mediaRec);
    playerRec = NULL;
}


__declspec(dllexport) float GetBufferState() {
    if (player) {
        libvlc_state_t state = libvlc_media_player_get_state(player);
        if (state == libvlc_Buffering) {
            return 50.0f;  // Példa érték
        }
    }
    return 100.0f;
}

libvlc_state_t state;
libvlc_time_t duration;

__declspec(dllexport) int GetMediaDuration() {
    if (player) {
        libvlc_media_t* media = libvlc_media_player_get_media(player);
        if (media) {
            return static_cast<int>(libvlc_media_get_duration(media));
        }
    }
    return -1; // Ha nem elérhetõ
}

__declspec(dllexport) INT64 Getduration() {
    if (player) {
        state = libvlc_media_player_get_state(player);
        if (state == libvlc_state_t::libvlc_Playing)
        {
            duration = libvlc_media_get_duration(media);
            return (INT64)duration;
        }
        return (INT64)-1;
    }
    return (INT64)-1;
}

__declspec(dllexport) int Getstate() {
    if (player) {
        state = libvlc_media_player_get_state(player);
        return state;
    }
    return -1;
}

__declspec(dllexport) void Play(char* url)
{
    if (url == NULL) {
        if (player) {
            state = libvlc_media_player_get_state(player);
            if (state == libvlc_state_t::libvlc_Playing) {
                libvlc_media_player_pause(player);
                return;
            }
            else if (state == libvlc_state_t::libvlc_Paused) {
                libvlc_media_player_play(player);
                return;
            }
        }
    }
    if (player) {
        libvlc_media_player_stop(player);
        libvlc_media_release(media);
        player = NULL;
    }
    if (playerRec)
    {
        libvlc_media_player_stop(playerRec);
        libvlc_media_release(mediaRec);
        playerRec = NULL;
    }
    media = libvlc_media_new_location(vlc, url);
    player = libvlc_media_player_new_from_media(media);
    libvlc_media_player_play(player);
    //attachBufferEvent(player);
}

__declspec(dllexport) void  Stop()
{
    if (player) {
        libvlc_media_player_stop(player);
        libvlc_media_release(media);
        player = NULL;
    }
    if (playerRec) {
        libvlc_media_player_stop(playerRec);
        libvlc_media_release(mediaRec);
        playerRec = NULL;
    }
}

__declspec(dllexport) void  Pause()
{
    libvlc_media_player_pause(player);
}

__declspec(dllexport) void PlayFile(const char* file_path) {
    if (player) {
        libvlc_media_player_stop(player);
        libvlc_media_release(media);
    }

    media = libvlc_media_new_path(vlc, file_path);
    if (!media) {
        std::cerr << "Nem sikerült létrehozni a média objektumot!" << std::endl;
        return;
    }

    player = libvlc_media_player_new_from_media(media);
    libvlc_media_player_play(player);
}



__declspec(dllexport) void ChangeStation(const char* url) {
    if (player) {
        libvlc_media_player_stop(player);
        libvlc_media_release(media);
        player = NULL;
    }
    if (playerRec)
    {
        libvlc_media_player_stop(playerRec);
        libvlc_media_release(mediaRec);
        playerRec = NULL;
    }
    media = libvlc_media_new_location(vlc, url);
    player = libvlc_media_player_new_from_media(media);
    libvlc_media_player_play(player);
}

__declspec(dllexport) void SetVolume(int volume) {
    if (player) {
        libvlc_audio_set_volume(player, volume);
    }
}

__declspec(dllexport) INT64 GetPosition() {
    if (player) {
        libvlc_time_t tm = libvlc_media_player_get_time(player);
        //libvlc_time_t tt = libvlc_media_get_duration(media);
        return tm;
    }
    return -1;
}

__declspec(dllexport) void PausePlay() {
    if (player) {
        state = libvlc_media_player_get_state(player);
        if (state == libvlc_state_t::libvlc_Playing) libvlc_media_player_pause(player);
        else libvlc_media_player_play(player);
    }
}

__declspec(dllexport) void Seek(float pos) {
    if (player) {
        libvlc_media_player_set_position(player, pos);
        //libvlc_media_player_set_time(player, pos);
    }
}

void bufferChangedCallback(const libvlc_event_t* event, void* data) {
    if (bufferCallback) {
        bufferCallback(event->u.media_player_buffering.new_cache);
    }
}

__declspec(dllexport) void AttachBufferEvent(BufferCallback cb) {
    bufferCallback = cb;
    if (player) {
        libvlc_event_manager_t* em = libvlc_media_player_event_manager(player);
        if (libvlc_event_attach(em, libvlc_MediaPlayerBuffering, bufferChangedCallback, nullptr) == 0) {
            std::cout << "Buffer esemény hozzácsatolva!" << std::endl;
        }
        else {
            std::cerr << "Hiba: Buffer esemény csatolás sikertelen!" << std::endl;
        }
    }
    else {
        std::cerr << "Hiba: Player nincs inicializálva!" << std::endl;
    }
}

void onPlaying(const libvlc_event_t* event, void* data) {
    if (playingCallback) {
        playingCallback();
    }
}

__declspec(dllexport) void RegisterPlayingCallback(PlayingCallback cb) {
    playingCallback = cb;
}

__declspec(dllexport) void AttachPlayingEvent() {
    if (player) {
        libvlc_event_manager_t* em = libvlc_media_player_event_manager(player);
        libvlc_event_attach(em, libvlc_MediaPlayerPlaying, onPlaying, nullptr);
    }
}