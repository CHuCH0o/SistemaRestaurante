SistemaRestaurante

Proyecto de consola en C# usando únicamente estructuras hechas a mano como listas enlazadas, pilas y colas.
Este sistema permite manejar restaurantes, clientes, platos, pedidos y reportes diarios.

Cómo se creó este proyecto (paso a paso)

Esta es la explicación como si fuera un trabajo estudiantil, con los pasos reales que seguiría un estudiante.

Paso 1: Crear el proyecto vacío

Paso 2: Crear las estructuras básicas

Antes de hacer cualquier menú, se crearon las estructuras manuales:

Nodo.cs

ListaEnlazada.cs

Cola.cs

Pila.cs

Estas clases se hicieron primero para tener dónde guardar restaurantes, clientes, platos y pedidos.

Paso 3: Crear las clases del dominio

Se agregaron las clases que representan objetos del mundo real:

Restaurante.cs

Cliente.cs

Plato.cs

Pedido.cs (con PlatoPedido adentro)

En este punto solo tenían atributos básicos, sin menús.

Paso 4: Implementar el menú principal

En Program.cs, se hizo el menú:

=== SISTEMA RESTAURANTE ===
1. Restaurantes
2. Clientes
3. Platos
4. Pedidos
5. Reportes
99. Salir


Y se dejó conectado a las clases.

Paso 5: Crear el menú de restaurantes

En Restaurante.cs se agregaron:

Crear restaurante

Editar restaurante

Listar restaurantes

Seleccionar restaurante

Todo usando la lista enlazada.

Paso 6: Hacer el menú de clientes

En Cliente.cs se agregaron:

Agregar cliente

Editar cliente

Seleccionar cliente

Listar clientes

Validaciones de celular y email

Paso 7: Crear el menú de platos

En Plato.cs:

Agregar

Editar

Listar

Selección por menú numérico

Paso 8: Implementar pedidos

En Pedido.cs:

Tomar pedido

Agregar platos al pedido

Calcular total

Guardar en la cola de pedidos

Paso 9: Implementar cola de pedidos y despachos

Se agregaron:

Ver pedidos pendientes

Despachar pedido

Mover pedido al historial (pila)

Paso 10: Crear los reportes

Finalmente:

Platos servidos hoy

Ganancias del día

 Funciones principales

1. Restaurantes
2. Clientes
3. Platos
4. Pedidos
5. Reportes

Estructura del proyecto
SistemaRestaurante/
Program.cs
Restaurante.cs
Cliente.cs
Plato.cs
Pedido.cs
Nodo.cs
ListaEnlazada.cs
Cola.cs
Pila.cs