using TestInterview;

Employee E = new Employee();
E.EmpId = 12;
E.show();
VisitingEmployee VE= new VisitingEmployee();
VE.EmpId = 23;
VE.show();

Console.WriteLine(E.EmpId);
Console.ReadLine();

Console.WriteLine(VE.EmpId);
Console.ReadLine();
