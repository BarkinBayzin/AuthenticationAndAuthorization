using AuthenticationAndAuthorization.Models.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace AuthenticationAndAuthorization.Models.Entities.Concrete
{
    //IdentityUser => Microsoft.Extensions.Identity.Stores sahip paket yüklendi.
    //AspNetCore.Identity bize hazır olarak sunulmuş bir sınıf. AspNetCore.Identity aracılığı ile işlemlerimizi hızlıca yürütebiliriz. İçerisinde kullanıcının tüm işlemlerini yürütebileceğimiz hazır CRUD methodlar ve migration ile veritabanına hızlı gönderebilecğiniz sınıflar bulunmaktadır. Kullanıcı işlemleri için veri tabanında ve uygulama tarafında hazırlaması gereken varlıkları bize 8 adet sınıf aracılığıyla sunmaktadır. Migration esnasında göç ettrilen sınıflar incelendiğinde bunu görebilirisiniz. Bunun yanında authentication işlemleri için yada CRUD operasyonlarında kullanabileceğiniz hazır metotlar senkron ve asenkron program için bizlere sunmaktadır. Örneğin check credention, password hasher, login ve registration işlemleride kolaylıkla yürütülebilir.

    //Günümüzde birçok firma Identity mekanızması üzerine kendi yapılıranı yada projede ihtiyaç duydukları özellikleri kazandırarak kendi Identity yapılarını oluşturmaktadır. Bizde aşğıda görebilecğeiniz gibi Identity ile gelen user özelliklerinin yanına minik bir lok özelligleri ve meslek alanı ekledir.
    public class AppUser : IdentityUser, IBaseEntity//IBaseEntity sınıfını oluştuturken tartıştığımız konu burada karşımıza geldi. Çoklu kalıtım temin etmek için ata sınıfı interface olarak açmak zorunda kaldık.
    {

        //AppUser sınıfımızı IdentityUser.cs sınıfından kalıtım almakta böylelikle IdentityUser.cs sınıfının bize sunfuğu üyelerden faydalanmakta. Lakin IdentityUser.cs sınıfı ihtiyaçlarımızı karşılamaz ise ihtiyacımız olan üyeleri biz ekleyebiliriz.

        public string Occupation { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
