using System;

namespace AuthenticationAndAuthorization.Models.Entities.Interfaces
{
    public enum Status { Active = 1, Modified, Passive}
    public interface IBaseEntity
    {
        //IBaseEntity.cs sınıfında yada daha önce hazırladığımız base sınıf mantıklarında her zaman ID'yi ilgili ata sınıftan dağıtırdık. Bu projede bunu yapmadık. Çünkü "AppUser.cs" sınıfında IdentityUser.cs sınıfının bize sunduğu hazır varlıklardan faydalanacağız ve farkına varacağınz gibi bu harız varlıkların kendi Id'leri ve iyi bir şekilde düşünülmüş kullanıcı bazlı üyerleri bulunmaktadır. Bu yüzde IBaseEntity içerisinde Id barındırmadık. Şayet bunu yapsaydık IdentityUser ile IBaseEntity üzerinden dağıttımız Id'ler çakışacaktı....

        //Ayrıca arayüzlere bu şekilde üye tanımlamanın yazılım dünyasında hoş karşılanmadığını unutmayalım ama bizim uygulumamızdaki AppUser sınıfı concrete olan Identity sınıfından miras alacağından buada AppUser'ın soyutlamaya bağlı kalması açısından interface kullanmak zorundaydık.
        public DateTime CreateDate{ get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
