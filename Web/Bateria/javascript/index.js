const numbotones = document.querySelectorAll('button').length;
const botones = document.querySelectorAll('button');

for(let i = 0; i < numbotones; i++){
  botones[i].addEventListener('click', function(){
    let audio1;


    if (this.textContent === "l") {
      audio1 = new Audio('sounds/tom-1.mp3');
    } else if (this.textContent === "k") {
      audio1 = new Audio('sounds/tom-2.mp3');
    } else if (this.textContent === "j") {
      audio1 = new Audio('sounds/tom-3.mp3');
    } else if (this.textContent === "d") {
      audio1 = new Audio('sounds/tom-4.mp3');
    } else if (this.textContent === "s") {
      audio1 = new Audio('sounds/snare.mp3');
    } else if (this.textContent === "a") {
      audio1 = new Audio('sounds/kick-bass.mp3');
    } else if (this.textContent === "w") {
      audio1 = new Audio('sounds/crash.mp3');
    }

   
    if (audio1) {
      audio1.play();
    }

    console.log("Texto del botón: " + this.textContent);
  });
}

document.addEventListener("keydown", function(event){

  console.log(event);
  let audio1;


  if (event.key === "l") {
    audio1 = new Audio('sounds/tom-1.mp3');
  } else if (event.key === "k") {
    audio1 = new Audio('sounds/tom-2.mp3');
  } else if (event.key === "j") {
    audio1 = new Audio('sounds/tom-3.mp3');
  } else if (event.key === "d") {
    audio1 = new Audio('sounds/tom-4.mp3');
  } else if (event.key === "s") {
    audio1 = new Audio('sounds/snare.mp3');
  } else if (event.key === "a") {
    audio1 = new Audio('sounds/kick-bass.mp3');
  } else if (event.key === "w") {
    audio1 = new Audio('sounds/crash.mp3');
  }

 
  if (audio1) {
    audio1.play();
  }
});