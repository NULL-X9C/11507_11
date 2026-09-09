using HomeWork;
using HomeWork.Homeworks._14._03;
using HomeWork.ClassWork;
using HomeWork.Homeworks._4._04.CoffeeMachine;
using HomeWork.Homeworks._4._04.CoffeeMachine.Animation;
using HomeWork.Homeworks._11._04;
 var FiltProc = new DotaParserProcessor();  // 7.03

 var sensorProc = new SensorProcessor();  //   14.03
 sensorProc.Process();

var WareHouseProc = new ProcessorWareHose();  //  ClassWork 21.03

WareHouseProc.StartProcess();

 var bigDataProc = new BigDataProcessor(); // 11/04
 bigDataProc.Run();
Console.WriteLine("Hello, World!");
