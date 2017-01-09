#Pizzabox Hardware / C# Raspberry PI GPIO Interface
IO Interface for PizzaBox

This is a C# program to interface with a Raspebery PI GPIO to control the hardware for the PizzaOrderbox.
Routines to interface with Domino's and actually order food are on devlaf's account under (https://github.com/devlaf/PizzaButton).

The hardware allows you to configure select different audio/alarm zones for notification, setup the order (add breadsticks / toppings), set the magnitude of pizza greatness, and once configured trigger the order placement.
Orders are subsequently tracked and visually indicated through a series of rotating light beacons and audibly through bells and chimes.

Two sets of tracking hardware units have been deployed for Unit 2 / Unit 1 which are communicated through IOS Nodes
[Unit 1 Beacon Lights] (https://github.com/leibert/ESPNode/tree/master/deployed/Unit%201%20Beacon%20Lights/ESPNode)
[Unit 1 Beacon Lights] (https://github.com/leibert/ESPNode/tree/master/deployed/Unit%202%20Beacon%20Lights/ESPNode)
