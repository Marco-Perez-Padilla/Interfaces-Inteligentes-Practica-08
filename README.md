# Interfaces-Inteligentes-Practica-08

En esta práctica se experimenta con micrófono y cámara del ordenador

---

### 1. Reproducción de un sonido cuando hay colisión

Utilizar la escena de los guerreros y activa la reproducción de los sonidos incluidos en la carpeta adjunta cuando un guerrero alcanza algún objetivo.

Para este ejercicio se ha requerido de:
- Cubo como personaje jugable que se mueve con wasd.
- Cuando el cubo colisiona con un guerrero, activa un evento que hace que el guerrero avance hacia el escudo.
- Cuando el guerrero colisiona con el escudo, suena un audio.
  
**Scripts:**  
- [MovementWithRigidbody.cs](Scripts/MovementWithRigidbody.cs)  
- [MessageOnGrab.cs](Scripts/HumanoidNotificator.cs)
- [HumanoidResponse1.cs](Scripts/HumanoidResponse1.cs)  
- [ShieldDetector1.css](Scripts/ShieldDetector1.cs)  

[Ver video](Videos/VID-E-1mp4)


### 2. Captura y reproducción de micrófono y frames de la cámara
Crea una escena en el que habrá una pantalla central con altavoces que al pulsar la tecla R reproduzcan el sonido que se obtenga por el micrófono del dispositivo.
Capturar frames de la cámara.

Para este ejercicio se ha hecho:
- Creación de un Quad en donde se reproducen las imagenes captadas por la cámara. Si se pulsa "S" se guarda el fotograma concreto en el momento de pulsar la tecla. Si se pulsa "F" se guarda en un fichero
- Al lado del Quad que sirve de pantalla se crean dos objetos AudioSource y se vinculan al Quad como hijos. Altavoces.md se pone como componente del Quad y maneja la reproducción del audio del micrófono tras pulsar "R" por los dos altavoces simultáneamente

**Scripts:**  
- [CameraCapture.cs](Scripts/CameraCapture.cs)  
- [Altavoces.cs](Scripts/Altavoces.cs)

