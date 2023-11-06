# Enoca Backend Challenge
### Projede kullanılan teknik ve teknolojiler
* Net Core 6 API
*	MSSQL
*	Swagger UI
*	Entity Framework - Code First Approach
*	Repository Design Pattern
* CQRS Design Pattern - Mediatr
*	Onion Architecture
*	AutoMapper
*	IoC
* Hangfire
  
# Projenin amacı
* Müşterinin siparişi esnasında girilen desi bilgisine göre otomatik olarak
kargo firmasını seçen .NET API projesi geliştirildi.
* Müşteri sipariş oluşturduğu esnada daha önce kargo firmalarına
tanımlayan veriler üzerinden siparişin desi miktarına göre kargo ücretinin
hesaplanması sağlandı, ilgili veriler sipariş tablosuna kayıt edildi.
* Her saat başı kargolar, kargo günü ve kargo firmalarına göre gruplandırılıp Rapor tablosuna kaydedildi.
