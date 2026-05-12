# Ahorcado con .NET

Este proyecto es una implementación del juego del ahorcado usando .NET. El juego permite a los jugadores adivinar una palabra oculta letra por letra, con un número limitado de intentos antes de perder.

**Autor:** Carlos Alfonso Llanes

## Descripción del Sistema

El sistema es una aplicación de consola interactiva que simula el juego del ahorcado adaptado a un vocabulario técnico.

El jugador tiene 6 intentos para adivinar la palabra ingresando letras una por una, el sistema dibuja progresivamente al ahorcado en la consola tras cada fallo y propoorciona una pista al jugador cuando le quedan 3 intentos o menos.

## Estructura del Proyecto

El código está dividido en dos etapas para fines de evaluación:
1. **Versión original:** Aquí `Juego.cs` tiene un enfoque monolítico, con toda la lógica del juego en un solo archivo.
2. **Versión refactorizada:** Aquí `Juego.cs` se ha refactorizado para mejorar la legibilidad y mantenibilidad, separando la lógica en métodos más pequeños y claros.


## Análisis de violaciones SOLID
En la primera etapa de desarrollo, la clase `Juego.cs` presentaba severos problemas de diseño arquitectónico. A continuación, se identifican las tres violaciones principales a los principios SOLID:

### 1. Violación a SRP (Principio de Responsabilidad Única)
La clase `Juego.cs` conocida como "Clase Dios" tenía múltiples razones para cambiar porque mezclaba tres responsabilidades distintas:
* **Gestión de Datos:** Contenía la lista dura (hardcoded) de las palabras secretas.
* **Lógica de Negocio:** Se encargaba de restar los intentos, validar las letras repetidas y determinar la condición de victoria.
* **Interfaz de Usuario (UI):** Contenía instrucciones directas de `Console.WriteLine` y `Console.Clear()` para dibujar al ahorcado y pedir datos al usuario.

**Solución:** Se separó la UI en `ConsolaUI.cs`, la lógica en `MotorAhorcado.cs` y los datos en `PalabrasEnMemoria.cs`.

### 2. Violación a OCP (Principio de Abierto/Cerrado)
El diseño original no estaba abierto a la extensión ni cerrado a la modificación. Cuando se requirió implementar la nueva funcionalidad de Categorías de Palabras (Arquitectura, POO, .NET), hubiese sido necesario entrar a modificar el código fuente de `Juego.cs` para agregar más listas y validaciones.

**Solución:** Al refactorizar, la clase `MotorAhorcado` quedó cerrada a modificaciones (no tuvimos que tocarla para la tarea de categorías), pero abierta a extensiones porque ahora recibe las palabras ya filtradas desde el exterior.

### 3. Violación a DIP (Principio de Inversión de Dependencias)
En el primer diseño, el juego dependía directamente de detalles de implementación muy concretos. Estaba fuertemente acoplado a una clase `List<string>` específica y al uso directo de `new Random()` dentro de su propio constructor. 

**Solución:** Se implementó la interfaz `IRepositorioPalabras`. Ahora el módulo de alto nivel (`MotorAhorcado`) no depende de detalles de bajo nivel, sino que depende exclusivamente de la abstracción. 

---

## Características de la Versión Final
* Implementación de Inyección de Dependencias.
* Selección de categorías al inicio de la partida.
* Sistema de pistas automático al llegar a 3 fallos.
* Ciclo de juego continuo.

## Imágenes
<img width="798" height="208" alt="Captura de pantalla 2026-05-12 155105" src="https://github.com/user-attachments/assets/76b62f67-86a5-43a2-ad28-05e70ebb2b2d" />

<img width="402" height="352" alt="Captura de pantalla 2026-05-12 155121" src="https://github.com/user-attachments/assets/7854e9f1-086d-4494-98b6-6f14a2c9de6e" />

<img width="701" height="457" alt="Captura de pantalla 2026-05-12 155227" src="https://github.com/user-attachments/assets/1ebc88bb-97e2-4b42-920f-ab1c894839af" />


## Cláusula de IA
Yo Carlos Alfonso Llanes Rodriguez declaro haber usado IA, específicamente GEMINI, para unir los códigos proporcionados en la presentación y también para entender como hacer los cambios de las categorás de palabras.
