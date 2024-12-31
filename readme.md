# Web API for BMI Calculation

這個程式是一個 Web API，主要用於計算 BMI（Body Mass Index）。此範例是為了 Power Automate 做 custom connector 使用的。

## 功能

- 接收身高（厘米）和體重（公斤）作為輸入
- 計算並返回 BMI 值

## API 說明

### 計算 BMI

- **URL**: `/bmi`
- **方法**: `POST`
- **請求體**:
  ```json
  {
    "HeightCm": double,
    "WeightKg": double
  }
  ```

### 使用說明

在使用此 API 前，請確保已經修改 `program.cs` 中的 Swagger 伺服器 URL。該 URL 應該是可以公開使用的，建議使用 [devtunnel](https://aka.ms/devtunnel) 來建立公開的 URL。

#### 修改 `program.cs`

1. 打開 `program.cs` 文件。
2. 找到設定 Swagger 伺服器 URL 的部分，通常是在 `builder.Services.AddSwaggerGen()` 或 `app.UseSwagger()` 之後。
3. 將 URL 修改為 devtunnel 提供的公開 URL。

例如：
```csharp
var builder = WebApplication.CreateBuilder(args);

// 其他設定...

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddServer(new OpenApiServer
    {
        Url = "https://your-devtunnel-url"
    });
});

var app = builder.Build();

// 其他設定...

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.Run();
```

請將 `"https://your-devtunnel-url"` 替換為實際的 devtunnel URL。

### DevTunnel 使用方式
devtunnel host -p 5089 --allow-anonymous