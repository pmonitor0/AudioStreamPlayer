## Köszönetnyilvánítás
- A [ChatGPT](https://openai.com/chatgpt) által nyújtott segítségért, amely hozzájárult a projekt egyes részeinek megvalósításához.

Az AudioStreamPlayer telepítése:
1: Telepíteni kell a VLC Media Player alkalmazás windows 64 bites verzióját.
2: Le kell tölteni az AudioStreamPlayer-t innen, és ki kell bontani.
3: A VLC telepítési mappájában találhatók a "plugins" mappa, valamint a libvlc.dll és a libvlccore.dll fájlok.
4: Az AudioStreamPlayer mappában található az AudioStreamPlayer.sln fájl. Ennek a kimeneti mappájába kell másolni a 3. pontban levő mappát és fájlokat(a futtatható AudioStreamPlayer.exe mellé).
5: El kell indítani az AudioStreamPlayer.sln fájlt a Visual Studio-val.
6: Be kell állítani a Release|x64 platformot.
7: Build -> ReBuild Solution menüpontot kell elindítani. Elvileg Hibamentesen lefordul.

Az AudioStreamPlayer használata:
1: EL kell indítani a kimeneti mappában az AudioStreamPlayer.exe alkalmazást.
2: A bal oldali listában van 1-2 rádió. Dupla kattintással(vagy enter megnyomásával) kezdi el lejátszani a kiválasztott rádiót.
3: Ha olyan track-eket szeretnénk lejátszani, amelyeknek ismert a hossza(az asztali gépen lévő zenék), akkor a jobb oldali listába drag & drop módszerrel tudjuk importálni a zenéket.
4: A jobb oldali lista törlése jelenleg a "Lista törlése" nevű gomb megnyomásával történik.
5: Sajnos a jelenlegi állapotában az AudioStreamPlayer elég kezdetleges. De az idő majd segít rajta.
