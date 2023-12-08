
# Weather API 🌟

Projenin temel amacı, çeşitli gezegenler ve gezegenlerin uydularının sıcaklık bilgilerini sağlayan bir API geliştirmektir. Bu projenin hedefi ise programlamada C# dilini ve .NET dünyasını öğrenmek ve bu alanda ilerlemek için tecrübe kazanmaktır. Projeyi geliştirirken SOLID yazılım tekniklerini de kullanarak bu teknikleri uygulamalı olarak öğrenme fırsatı buldum. Bu proje, yazılım geliştirici olma yolundaki gelişimime katkı sağlayarak temelimi sağlam atmama yardımcı oldu.

## C# Backend Katmanlar

- **Core:** Toolların diğer projelerde kullanılmasını sağlayan genel bir katmandır.
- **Entities:** Veritabanındaki tabloları nesneye dönüştürdüğümüz katman.
- **DataAccess:** Veritabanı işlemlerini yaptığımız katman.
- **Business:** İş kurallarımızı geliştirdiğimiz katman.
- **WebAPI:** Restful (Representational State Transfer) HTTP protokolü ile sunucu-istemci iletişimi sağladığımız katman.

## Auth İşlemleri ☑️

- Kullanıcı kayıt olma
- Kullanıcı giriş yapma


## Kullanıcı İşlemleri ☑️

- Kullanıcı ekleme
- Kullanıcı silme
- Kullanıcı güncelleme
- Kullanıcı listeleme
- Profil düzenleme

## Gezegen İşlemleri ☑️

- Gezegen ekleme
- Gezegen silme
- Gezegen güncelleme
- Gezegen listeleme

## Uydu İşlemleri ☑️

- Uydu ekleme
- Uydu silme
- Uydu güncelleme
- Uydu listeleme


# AuthController API Dökümantasyonu

AuthController, kimlik doğrulama ve kullanıcı işlemleri için kullanılan API kontrollerini içerir.

## Endpointler

### Login

Kullanıcının giriş yapmasını sağlayan bir POST isteği yapar.

```http
POST /api/v1/auth/login
```

#### İstek Parametreleri

| Parametre          | Tip               | Açıklama                                           |
| ------------------ | ----------------- | -------------------------------------------------- |
| userForLoginDto    | UserForLoginDto   | Giriş yapmak için kullanıcının bilgilerini içerir.  |

#### İstek Gövdesi (Request Body)

```json
{
  "email": "example@example.com",
  "password": "password123"
}
```

#### Cevaplar

- 200 OK: Giriş başarılıysa ve erişim anahtarı oluşturulduysa dönüş yapılır.
- 400 Bad Request: Giriş başarısız veya hatalı istek yapıldığında dönüş yapılır.

### Register

Yeni bir kullanıcının kaydolmasını sağlayan bir POST isteği yapar.

```http
POST /api/v1/auth/register
```

#### İstek Parametreleri

| Parametre              | Tip                 | Açıklama                                           |
| ---------------------- | ------------------- | -------------------------------------------------- |
| userForRegisterDto     | UserForRegisterDto  | Yeni kullanıcının kaydolması için gerekli bilgileri içerir.  |

#### İstek Gövdesi (Request Body)

```json
{
  "email": "string",
  "password": "string",
  "firstName": "string",
  "lastName": "string"
}
```

#### Cevaplar

- 200 OK: Kayıt başarılıysa ve erişim anahtarı oluşturulduysa dönüş yapılır.
- 400 Bad Request: Kayıt başarısız veya hatalı istek yapıldığında dönüş yapılır.

---

Bu API dokümantasyonu AuthController'daki endpointlerin kullanımını ve parametrelerini açıklar.

# UsersController API Dokümantasyonu

UserControllers, kullanıcı işlemleri için API denetleyicilerini içerir.

## Endpoints

### Ekle

Yeni bir kullanıcı eklemek için POST isteği yapar.

```http
POST /api/v1/users
```

#### İstek Parametreleri

| Parametre | Tip  | Açıklama                   |
| --------- | ---- | --------------------------- |
| user      | User | Eklenmek istenen kullanıcının bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "passwordSalt": "string",
  "passwordHash": "string",
  "status": true
}
```

#### Yanıtlar

- 200 OK: Kullanıcı başarıyla eklenirse sonucu döndürür
- 400 Bad Request: Kullanıcı eklenemezse hata döndürür

### Sil

Bir kullanıcıyı silmek için DELETE isteği yapar.

```http
DELETE /api/v1/users
```

#### İstek Parametreleri

| Parametre | Tip  | Açıklama                      |
| --------- | ---- | ------------------------------ |
| user      | User | Silinmek istenen kullanıcının bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "passwordSalt": "string",
  "passwordHash": "string",
  "status": true
}
```

#### Yanıtlar

- 200 OK: Kullanıcı başarıyla silinirse sonucu döndürür
- 401 Unauthorized: İstek yetkilendirilmediyse hata döndürür
- 400 Bad Request: Kullanıcı silinemezse hata döndürür

### Güncelle

Bir kullanıcıyı güncellemek için PUT isteği yapar.

```http
PUT /api/v1/users
```

#### İstek Parametreleri

| Parametre | Tip  | Açıklama                     |
| --------- | ---- | ----------------------------- |
| user      | User | Güncellenmek istenen kullanıcının bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "passwordSalt": "string",
  "passwordHash": "string",
  "status": true
}
```

#### Yanıtlar

- 200 OK: Kullanıcı başarıyla güncellenirse sonucu döndürür
- 400 Bad Request: Kullanıcı güncellenemezse hata döndürür

### Profili Yama

Bir kullanıcının profilini kısmen güncellemek için PATCH isteği yapar.

```http
PATCH /api/v1/users/editprofile/{id}
```

#### İstek Parametreleri

| Parametre     | Tip                | Açıklama                                          |
| ------------- | ------------------  | -------------------------------------------------- |
| id            | Guid                | Güncellenmek istenen kullanıcının kimliği         |
| patchDocument | JsonPatchDocument   | Güncellenecek alanları içeren belge               |

#### İstek Gövdesi

```json
[
  {
    "operationType": 0,
    "path": "string",
    "op": "string",
    "from": "string",
    "value": "string"
  }
]
```

#### Yanıtlar

- 200 OK: Kullanıcının profili başarıyla güncellenirse sonucu döndürür
- 400 Bad Request: Kullanıcının profili güncellenemezse hata döndürür

### Tümünü Listele

Tüm kullanıcıları almak için GET isteği yapar.

```http
GET /api/v1/users?status=true&sortOrder=asc&page=1&size=10
```

#### İstek Parametreleri

| Parametre   | Tip     | Açıklama                      |
| ----------- | -------  | ------------------------------ |
| status      | bool     | Kullanıcıların durumunu belirtir|
| sortOrder   | string   | Sıralama düzenini belirtir    |
| page        | int      | Sayfa numarasını belirtir      |
| size        | int      | Sayfa boyutunu belirtir        |

#### Yanıtlar

- 200 OK: Kullanıcılar başarıyla alınırsa sonucu döndürür
- 400 Bad Request: Kullanıcılar alınamazsa hata döndürür

### Kimliğe Göre

Bir kullanıcıyı kimliğine göre almak için GET isteği yapar.

```http
GET /api/v1/users/getbyid/{id}
```

#### İstek Parametreleri

| Parametre   | Tip   | Açıklama                      |
| ----------- | ------ | ----------------------------- |
| id          | Guid   | Kullanıcının kimliği          |

#### Yanıtlar

- 200 OK: Kullanıcı başarıyla alınırsa sonucu döndürür
- 400 Bad Request: Kullanıcı alınamazsa hata döndürür

### E-Posta Adresine Göre

Bir kullanıcıyı e-posta adresine göre almak için GET isteği yapar.

```http
GET /api/v1/users/getbymail?email={email}
```

#### İstek Parametreleri

| Parametre   | Tip   | Açıklama                      |
| ----------- | ------ | ----------------------------- |
| email       | string | Kullanıcının e-posta adresi    |

#### Yanıtlar

- 200 OK: Kullanıcı başarıyla alınırsa sonucu döndürür
- 400 BadRequest: Kullanıcı alınamazsa hata döndürür

# PlanetsController API Dokümantasyonu

PlanetsController, gezegen işlemleri için API endpoint'leri içerir.

## Endpointler

### Add

Yeni bir gezegen eklemek için bir POST isteği yapar.

```http
POST /api/v1/planets
```

#### İstek Parametreleri

| Parametre | Tür          | Açıklama                                   |
| --------- | ------------ | ------------------------------------------ |
| planet    | PlanetAddDto | Eklenmek istenen gezegenin bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": 0,
  "satelliteId": 0,
  "name": "string",
  "weather": 0
}
```

#### Yanıtlar (Responses)

- 201 Created: Gezegen başarıyla eklendiyse sonucu döndürür.
- 400 Bad Request: Gezegen eklenemediyse bir hata döndürür.

### Delete

Bir gezegeni silmek için bir DELETE isteği yapar.

```http
DELETE /api/v1/planets
```

#### İstek Parametreleri

| Parametre | Tür              | Açıklama                                |
| --------- | ---------------- | --------------------------------------- |
| planet    | PlanetDeleteDto  | Silinmek istenen gezegenin bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": 0,
  "name": "string"
}
```

#### Yanıtlar (Responses)

- 204 No Content: Gezegen başarıyla silindiğinde sonucu döndürür.
- 400 Bad Request: Gezegen silinemediyse bir hata döndürür.

### Update

Bir gezegeni güncellemek için bir PUT isteği yapar.

```http
PUT /api/v1/planets
```

#### İstek Parametreleri

| Parametre | Tür     | Açıklama                      |
| --------- | ------- | ----------------------------- |
| planet    | Planet  | Güncellenmek istenen gezegenin bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": 0,
  "satelliteId": 0,
  "name": "string",
  "weather": 0
}
```

#### Yanıtlar (Responses)

- 200 OK: Gezegen başarıyla güncellendiğinde sonucu döndürür.
- 400 Bad Request: Gezegen güncellenemediyse bir hata döndürür.

### PatchProfile

Bir gezegenin ayrıntılarını kısmi olarak güncellemek için bir PATCH isteği yapar.

```http
PATCH /api/v1/planets/editplanet/{id}
```

#### İstek Parametreleri

| Parametre    | Tür               | Açıklama                                   |
| ------------ | ----------------- | ------------------------------------------ |
| id           | int               | Güncellenmek istenen gezegenin kimliği      |
| patchDocument| JsonPatchDocument | Gezegen ayrıntılarının güncelleme dokümanı   |

#### İstek Gövdesi

```json
[
   {
    "operationType": 0,
    "path": "string",
    "op": "string",
    "from": "string",
    "value": "string"
  }
]
```

#### Yanıtlar (Responses)

- 200 OK: Gezegen ayrıntıları başarıyla güncellendiğinde sonucu döndürür.
- 400 Bad Request: Gezegen ayrıntıları güncellenemediyse bir hata döndürür.

### GetAll

Tüm gezegenlerin listesini almak için bir GET isteği yapar.

```http
GET /api/v1/planets?sortBy=planetName&sortOrder=asc&page=1&size=10
```

#### İstek Parametreleri

| Parametre   | Tür     | Açıklama                                   |
| ----------- | ------- | ------------------------------------------ |
| sortBy      | string  | Sıralama için kullanılacak özellik adı       |
| sortOrder  | string  | Sıralama düzeni (asc veya desc)               |
| ----------- | ------- | ------------------------------------------ |
| page        | int     | Sayfa numarası                              |
| size        | int     | Sayfa başına döndürülecek öğe sayısı          |

#### Yanıtlar (Responses)

- 200 OK: Tüm gezegenlerin listesi başarıyla döndürüldüğünde sonucu döndürür.
- 400 Bad Request: Gezegenlerin listesi alınamadıysa bir hata döndürür.
- 404 Not Found: Eşleşen içerik bulunmazsa bir hata döndürür.

### GetById

Bir gezegenin ayrıntılarını kimliğiyle birlikte almak için bir GET isteği yapar.

```http
GET /api/v1/planets/{id}
```

#### İstek Parametreleri

| Parametre   | Tür     | Açıklama                                   |
| ----------- | ------- | ------------------------------------------ |
| id          | int     | Gezegenin kimliği                          |

#### Yanıtlar (Responses)

- 200 OK: Gezegen ayrıntıları başarıyla döndürüldüğünde sonucu döndürür.
- 400 Bad Request: Gezegen ayrıntıları alınamadıysa bir hata döndürür.

### GetPlanetDetail

Bir gezegenin ayrıntılarını kimliğiyle birlikte almak için bir GET isteği yapar.

```http
GET /api/v1/planets/getplanetdetailbyid/{id}
```

#### İstek Parametreleri

| Parametre   | Tür     | Açıklama                                   |
| ----------- | ------- | ------------------------------------------ |
| id          | int     | Gezegenin kimliği                          |

#### Yanıtlar (Responses)

- 200 OK: Gezegen ayrıntıları başarıyla döndürüldüğünde sonucu döndürür.
- 400 Bad Request: Gezegen ayrıntıları alınamadıysa bir hata döndürür.

### GetPlanetDetails

Tüm gezegenlerin ayrıntılarını almak için bir GET isteği yapar.

```http
GET /api/v1/planets/getplanetdetails
```

#### Yanıtlar (Responses)

- 200 OK: Tüm gezegen ayrıntıları başarıyla döndürüldüğünde sonucu döndürür.
- 400 Bad Request: Gezegen ayrıntıları alınamadıysa bir hata döndürür.

# SatellitesController API Dokümantasyonu

SatellitesController, uydu işlemleri için API endpoint'leri içerir.

## Endpointler

### Add

Yeni bir uydu eklemek için bir POST isteği yapar.

```http
POST /api/v1/satellites
```

#### İstek Parametreleri

| Parametre | Tür               | Açıklama                                   |
| --------- | ----------------- | ------------------------------------------ |
| satellite | SatelliteAddDto   | Eklenmek istenen uydunun bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "name": "string",
  "weather": 0
}
```

#### Yanıtlar (Responses)

- 201 Created: Uydu başarıyla eklendiyse sonucu döndürür.
- 400 Bad Request: Uydu eklenemediyse bir hata döndürür.

### Update

Bir uyduyu güncellemek için bir PUT isteği yapar.

```http
PUT /api/v1/satellites
```

#### İstek Parametreleri

| Parametre | Tür         | Açıklama                      |
| --------- | ----------- | ----------------------------- |
| satellite | Satellite   | Güncellenmek istenen uydunun bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": 0,
  "name": "string",
  "weather": 0
}
```

#### Yanıtlar (Responses)

- 200 OK: Uydu başarıyla güncellendiğinde sonucu döndürür.
- 400 Bad Request: Uydu güncellenemediyse bir hata döndürür.

### Delete

Bir uyduyu silmek için bir DELETE isteği yapar.

```http
DELETE /api/v1/satellites
```

#### İstek Parametreleri

| Parametre | Tür               | Açıklama                                |
| --------- | ----------------- | --------------------------------------- |
| satellite | SatelliteDeleteDto| Silinmek istenen uydunun bilgilerini içerir |

#### İstek Gövdesi

```json
{
  "id": 0,
  "name": "string"
}
```

#### Yanıtlar (Responses)

- 204 No Content: Uydu başarıyla silindiğinde sonucu döndürür.
- 400 Bad Request: Uydu silinemediyse bir hata döndürür.

### PatchProfile

Bir uyduyun ayrıntılarını kısmi olarak güncellemek için bir PATCH isteği yapar.

```http
PATCH /api/v1/satellites/editsatellite/{id}
```

#### İstek Parametreleri

| Parametre      | Tür                                | Açıklama                                   |
| -------------- | ---------------------------------- | ------------------------------------------ |
| id             | int                                | Güncellenmek istenen uydunun kimliği        |
| patchDocument  | JsonPatchDocument<SatelliteDetailDto>| Uydu ayrıntılarının güncelleme dokümanı   |

#### İstek Gövdesi

```json
[
  {
    "operationType": 0,
    "path": "string",
    "op": "string",
    "from": "string",
    "value": "string"
  }
]
```

#### Yanıtlar (Responses)

- 200 OK: Uydu ayrıntıları başarıyla güncellendiğinde sonucu döndürür.
- 400 Bad Request: Uydu ayrıntıları güncellenemediyse bir hata döndürür.

### GetAll

Tüm uyduların listesini almak için bir GET isteği yapar.

```http
GET /api/v1/satellites?sortBy=satelliteName&sortOrder=asc&page=1&size=10
```

#### İstek Parametreleri

| Parametre   | Tür     | Açıklama                                   |
| ----------- | ------- | ------------------------------------------ |
| sortBy     | Parametre   | Tür     | Açıklama                                   |
| ----------- | ------- | ------------------------------------------ |
| sortBy      | string  | Sıralama için kullanılacak özellik          |
| sortOrder   | string  | Sıralama düzeni (asc veya desc)             |
| page        | int     | Sayfalama için sayfa numarası               |
| size        | int     | Sayfalama için sayfa başına öğe sayısı      |

#### Yanıtlar (Responses)

- 200 OK: Uydu listesi başarıyla alındığında sonucu döndürür.
- 400 Bad Request: Uydu listesi alınamadıysa bir hata döndürür.

### GetById

Bir uyduyu kimliğiyle birlikte almak için bir GET isteği yapar.

```http
GET /api/v1/satellites/getbyid?id=1
```

#### İstek Parametreleri

| Parametre | Tür     | Açıklama                                |
| --------- | ------- | --------------------------------------- |
| id        | int     | Alınmak istenen uyduyun kimliği          |

#### Yanıtlar (Responses)

- 200 OK: Uydu başarıyla alındığında sonucu döndürür.
- 400 Bad Request: Uydu alınamadıysa bir hata döndürür.

## Notlar

- Tüm istekler JSON formatında gövde verisi bekler.
- Yanıtlar da JSON formatında döndürülür.

## Ekran Görüntüleri

![Uygulama Ekran Görüntüsü 0](https://github.com/Fimple-Net-Bootcamp/week2-ilhan48/blob/main/Assets/satelliteAdd.png)

![Uygulama Ekran Görüntüsü 1](https://github.com/Fimple-Net-Bootcamp/week2-ilhan48/blob/main/Assets/satelliteAddResult.png)

![Uygulama Ekran Görüntüsü 2](https://github.com/Fimple-Net-Bootcamp/week2-ilhan48/blob/main/Assets/satellitesGet.png)

![Uygulama Ekran Görüntüsü 3](https://github.com/Fimple-Net-Bootcamp/week2-ilhan48/blob/main/Assets/satellitesResult.png)

![Uygulama Ekran Görüntüsü 4](https://github.com/Fimple-Net-Bootcamp/week2-ilhan48/blob/main/Assets/models.png)


