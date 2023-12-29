
Bu projede, bir ürün yönetimi sistemi sunan basit bir Web API bulunmaktadır. Proje, .NET Core teknolojisi kullanılarak geliştirilmiştir ve aşağıdaki özelliklere sahiptir:

- **Fake Ürün ve Kullanıcı Servisleri:** Proje, gerçek bir veritabanı kullanmaksızın fake ürün ve kullanıcı servislerini içerir. Bu servisler, API'nin temel işlevselliğini sağlar.

- **Swagger Desteği:** Projede, API dokümantasyonu için Swagger entegrasyonu bulunmaktadır. Swagger, API'nizi daha iyi anlamak ve test etmek için harika bir araçtır.

- **Global Loglama Middleware:** Proje, her bir HTTP isteğinin başlangıcını loglayan basit bir global loglama middleware içerir.

- **Kullanıcı Doğrulama ve Yetkilendirme:** API'ye giriş yapmak için bir kullanıcı doğrulama mekanizması içerir. Ayrıca, bazı işlemleri sadece yetkilendirilmiş kullanıcıların gerçekleştirebilmesi için `Authorize` attribute'ü kullanılmıştır.

- **JsonPatch Desteği:** JSON Patch (RFC 6902) standardını destekleyen bir endpoint bulunmaktadır. Bu, belirli alanlarda güncellemeler yapmak için kullanışlıdır.

## Kurulum ve Çalıştırma

Projeyi çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1. **Gerekli Araçlar:**
   - Projeyi çalıştırmak için [Visual Studio Code](https://code.visualstudio.com/) veya [Visual Studio](https://visualstudio.microsoft.com/) gibi bir IDE kullanabilirsiniz.
   - [.NET Core SDK](https://dotnet.microsoft.com/download) yüklü olmalıdır.

2. **Projeyi İndirme:**
   - Projeyi bilgisayarınıza indirin: `git clone https://github.com/oguzhankoc55/Akb-week2.git`

3. **Proje Dizinine Gitme:**
   - İndirilen projenin dizinine gidin: `cd awesome-web-api`

4. **Projeyi Çalıştırma:**
   - Projeyi aşağıdaki komutla çalıştırın: `dotnet run`

5. **Swagger Dokümantasyonu:**
   - Projeyi başarıyla başlattıktan sonra, Swagger dokümantasyonu için tarayıcınızda `https://localhost:7149/swagger` adresini ziyaret edin.

