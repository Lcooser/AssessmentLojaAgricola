// scripts.js
function obterImagemAleatoria() {
    var imagensAleatorias = [
        "/images/imageTratorHomePage.jpg",
        "/images/imageTratorVerde.jpg",
        "/images/MaquinaAgricolaLaranja.png",
        "/images/MaquinaAgricolaPlantadeira.png",
        "/images/MaquinaAgricolaPlantadeiraLaranja.png",
        "/images/MaquinaAgricolaPlantadeiraVermelha.png",
        "/images/MaquinaAgricolaTrator.png",
        "/images/MaquinaAgricolaTratorAzul.png",
    ];

    var indiceAleatorio = Math.floor(Math.random() * imagensAleatorias.length);
    return imagensAleatorias[indiceAleatorio];
}
