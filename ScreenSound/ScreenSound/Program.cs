using ScreenSound;

Album forMelancholyBrunettes = new Album("For MelancholyBrunettes", 400);
Banda banda = new Banda("Japanese Breakfast");
Musica musica1 = new Musica("Honey Water", banda, 200, true);


Musica musica2 = new Musica("Mega circuit", banda, 200, true);

forMelancholyBrunettes.AdicionarMusica(musica1);
forMelancholyBrunettes.AdicionarMusica(musica2);

forMelancholyBrunettes.MostrarAlbum();


banda.AdicionarAlbum(forMelancholyBrunettes);
banda.ExibirDiscografia();
