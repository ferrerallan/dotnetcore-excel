
using Application.UseCases.IntegrateSupplyChain;
using Main.Factories;

if (args.Length==0) {
  Console.WriteLine("param not passed");
  return;
}

switch (args[0])
{
  case "isc": 
    IntegrateSupplyChain();
    break;
  default: 
    Console.WriteLine("invalid param");
    break;
}

void IntegrateSupplyChain() {
  Console.WriteLine("usecase:integrating supply chain");
  var erpMapper = ERPMapperFactory.makeERPMapper(); 
  var suplierRepository = SupplierRepositoryFactory.makeSupplierRepository();
  var suplyChainDataSender = SupplyChainDataSenderFactory.makeSupplierChainDataSender();

  var integrateSupplyChain = new IntegrateSupplyChain(erpMapper, suplierRepository,suplyChainDataSender);

  var response = integrateSupplyChain.Integrate();

  Console.WriteLine(string.IsNullOrEmpty(response) ?"success integration!": $"***Fail=> {response}");
}
