**Autor:** Carlos Alfonso Llanes

## Descripción del Sistema

El sistema es una aplicación de consola interactiva que ofrece dos experiencias de juego:

### 1. Ahorcado
El jugador tiene 6 intentos para adivinar la palabra ingresando letras una por una. El sistema dibuja progresivamente al ahorcado en la consola tras cada fallo y proporciona una pista al jugador cuando le quedan 3 intentos o menos. El vocabulario está adaptado a términos técnicos organizados por categorías.

### 2. Viborita (Snake)
Un juego clásico donde el jugador controla una serpiente que debe comer comida para crecer. El objetivo es alcanzar 10 puntos sin chocar con los bordes del tablero o con el propio cuerpo de la serpiente. El jugador controla la dirección usando las teclas de flechas y puede salir en cualquier momento presionando 'Q'.

## Estructura del Proyecto (Aquí acerca de la Viborita)

### Juego de la Viborita
El juego está implementado siguiendo buenas prácticas de diseño:
- `MotorViborita.cs`: Lógica del juego (movimiento, colisiones, puntuación)
- `ConsolaUIViborita.cs`: Interfaz de usuario y renderizado del tablero
- `Program.cs`: Menú principal y control de flujo

### Viborita
* Control de dirección con teclas de flechas (↑ ↓ ← →).
* Sistema de puntuación de 10 puntos.
* Detección de colisiones con bordes y con el propio cuerpo.
* Velocidad de juego ajustable.
* Opción de salir en cualquier momento con la tecla Q.
* Ciclo de juego continuo.

## Cómo Jugar

### Ejecución
1. Ejecuta el programa.
2. Selecciona el juego que deseas jugar:
   - **1** para Ahorcado
   - **2** para Viborita

### Controles

**Viborita:**
- **↑** (Flecha arriba): Mover hacia arriba
- **↓** (Flecha abajo): Mover hacia abajo
- **←** (Flecha izquierda): Mover hacia la izquierda
- **→** (Flecha derecha): Mover hacia la derecha
- **Q**: Salir del juego

## Cláusula de IA
Yo Carlos Alfonso Llanes Rodriguez declaro haber usado IA, específicamente GEMINI y GitHub Copilot, para:
- Desarrollar la integración del juego Viborita al proyecto existente.
- Refactorizar el código para mantener buenas prácticas de diseño.
- Proporcionar estructura al README
