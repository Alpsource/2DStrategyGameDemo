# 2DStrategyGameDemo
 
> Infinite Scroll is used with object pooling.
> Buttons are created by using factory method, also they inherit from BasicButtonBehaviour class.
> EventManager class is created to handle custom events(publish - subscribe design pattern).
> Singletons are used most of the time.
> InputManager is created to handle inputs and trigger events which are changing grid model and make soldiers move wrt this changes. This is a small implementation of MVC pattern.
> An abstract class is created for buildings just to show implementation of polymorphism. But inheritance will be a better option for our situation.
> Coroutine is used for soldiers' movement, it is a better option than update because it doesn't work all the time.
> I also inherited soldiers from militaryUnit class in case of adding more military units (they all will have movement script) like flying soldiers, tanks, horse etc. and add a small script to soldier just to show implementation.
> Unity's Entity and math class is used in A* path finding algorithms. 
> Resharper is used too.
