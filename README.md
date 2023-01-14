# DLVR2
## Para el Modular mediante oculus.

### Configuracion de ambiente unity previo a descargar el repositorio.

### Crear el proyecto.
1. descargar Unity Hub.
2. instalar el editor 2022.1.xxxx o posterior.
3. añade los modulos "Android Build Support", "Android SDK & NDK Tools" and "OpenJDK".
4. Crea un proyecto core 3D.
5. activa el modo desarrollador en los oculus (mas info: https://business.oculus.com/support/1310318635799580/).

### Integracion de Oculus
1. Dentro del proyecto en la seccion Edit >> Proyect Settings >> XR Plugin Management: Instala el XR Plugin Management.
2. Activa Windows Oculus y Android Oculus.
3. Dirigete a la seccion Edit >> Projetc Settings >> Quality, elimina todas las calidades menos uno y asigna estos valores:
  > Name: VR
  
  > Pixel Light Count: 1
  
  > Anti Aliasing: 4x Multi Sampling
  
  > Anisotropic Textures: Per Texture
  
  > Soft Particles: off
4. Dirigite a la seccion File >> Build Settings >> Android y asigna los valores:
  > Texture Compression: ASTC
  
  - presiona Switch Platform
  - presiona Player Settings... te abrira otra ventana
5. Dentro de la seccion Proyect Settings >> Player >> Android >> Other Settings asigna los valores:
  > Color Space: Lineal
  
  > Auto Graphics API: off
  
  - Graphics APIs: (añade OpenGLES3)
  
  > Multithreaded Rendering: on
  
  > Static Batching: on
  
  > Dynamic Batching: on
  
  > GPU Compute Skinning: on
  
  > Minimum API Level: Level 23
  
  > Target API Level: Automatic
  
  > Install Location: Automatic 
6. Descarga e impora el package manager "Oculus Integration" desde la assetstore de unity: https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022
7. Presiona la siguiente secuencia de ventanas 
 - Update Oculus: yes 
 - Restart Unity: Restart 
 - Update Spatializer: Upgrate 
 - Restart Unity: Restart
