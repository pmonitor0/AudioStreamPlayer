#pragma once

#ifndef ASPLAYER_H // include guard
#define ASPLAYER_H

__declspec(dllexport) int __stdcall Init();
__declspec(dllexport) void __stdcall Play(char* url);
__declspec(dllexport) void __stdcall Stop();
__declspec(dllexport) void __stdcall Pause();
__declspec(dllexport) void ChangeStation(const char* url);
__declspec(dllexport) void SetVolume(int volume);
__declspec(dllexport) void StartRecorder(char* url);
__declspec(dllexport) void StopRecorder();
__declspec(dllexport) INT64 GetPosition();
__declspec(dllexport) int Getstate();
__declspec(dllexport) INT64 Getduration();
__declspec(dllexport) void PlayFile(const char* file_path);
__declspec(dllexport) int GetMediaDuration();
typedef void (*PlayingCallback)();
__declspec(dllexport) void RegisterPlayingCallback(PlayingCallback cb);
__declspec(dllexport) void Seek(float pos);
__declspec(dllexport) void PausePlay();
//__declspec(dllexport) void AttachPlayingEvent();
//__declspec(dllexport) void RegisterPlayingCallback(PlayingCallback cb)
#endif