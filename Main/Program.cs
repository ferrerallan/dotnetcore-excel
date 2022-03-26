
using Application.UseCases.IntegrateSupplyChain;
using Main.Factories;

var erpMapper = ERPMapperFactory.makeERPMapper(); 
var suplierRepository = SupplierRepositoryFactory.makeSupplierRepository();

var integrateSupplyChain = new IntegrateSupplyChain(erpMapper, suplierRepository);

var response = integrateSupplyChain.Integrate();

Console.WriteLine(string.IsNullOrEmpty(response) ?"success integration!": response);