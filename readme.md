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