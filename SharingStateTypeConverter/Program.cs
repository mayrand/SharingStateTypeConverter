using System;
using AutoMapper;

namespace SharingStateTypeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyView, CompanyResponse>());
            var mapper = config.CreateMapper();
            var m = mapper.Map<CompanyResponse>(new CompanyView()
            { Name = "asdf" });
            Console.WriteLine(m.SharingState);
        }
    }
    
    public class CompanyView 
    {
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual string Category { get; set; }      
        public virtual int SupplierId { get; set; }
        public virtual int? SharingState { get; set; }
    }
    public class CompanyResponse
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public SupplierScoreStatus SharingState { get; set; }
    }

    [Flags]
    public enum SupplierScoreStatus
    {
        None = 0,
        NotShared = 1,
        Shared = 2,
        Pending = 4
    }
}