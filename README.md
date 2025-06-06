![postman](https://user-images.githubusercontent.com/8418700/159980759-b9a94b90-5b9c-4745-878a-b2615ad17eff.png)

> Postman is an API platform for building and using APIs. Postman simplifies each step of the API lifecycle and streamlines collaboration so you can create better APIs—faster.

This library helps you to read a `Postman Collection v2.1` json file in C#.

### [Nuget](https://www.nuget.org/packages/PostmanCollectionReader)

[![Open Source Love](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/PostmanCollectionReader)
![Nuget](https://img.shields.io/nuget/dt/PostmanCollectionReader)


```
Install-Package PostmanCollectionReader

dotnet add package PostmanCollectionReader
```

### Usage

```cs
using PostmanCollectionReader;
var postmanCollection = PostmanCollection.FromJson(jsonString);
var environment = PostmanCollection.EnvironmentFromJson(jsonString);
```

---
**Based on `Postman Collection Format v2.1.0 Draft 07` schema and [QuickType](https://app.quicktype.io/).**
