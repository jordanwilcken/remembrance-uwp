window.onload = function () {
  //var theStuff = new persistence_component.Class1().doStuff();

  //document.getElementById("content").innerHTML = theStuff;

  new remembrance.RemembranceApp(
    document.getElementById("remembrance-container"),
    remembrance.appConfig)
    .start();
};
