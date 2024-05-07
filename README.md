# MessageQueue

## 專案紀錄
### 技術堆疊:
- Docker叢集: 用於建立和管理微服務容器
- RabbitMQ: 測試訊息佇列相關功能
- Entity Framework Code First & PostgreSQL: 作為主要資料庫，以實現資料持久化
- Repository模式: 通過Repository與資料庫進行溝通和操作
- Scrutor: 用於裝飾CacheRepository以提高效能
- Unit of Work模式: 用於統一管理資料庫交易
- MediatR: 實現CQRS模式，提高系統的鬆耦合性和可擴展性
- Mapster: 用於物件映射，使資料在不同層級之間轉換更加輕鬆
- FluentValidation: 用於對輸入資料進行驗證，增強系統的安全性和可靠性
- ExceptionHandler: 用於處理API錯誤，提供更好的用戶體驗和系統穩定性
- Carter:建立HTTP API端點

### 開發步驟:
- 建立Docker叢集環境，配置微服務容器
- 測試RabbitMQ相關功能，確保訊息佇列系統正常運作
- 使用Entity Framework Code First與PostgreSQL建立資料庫結構
- 實現Repository模式，建立與資料庫的溝通介面
- 使用Scrutor裝飾CacheRepository，提升資料存取效能
- 實現Unit of Work模式，統一管理資料庫交易
- 導入MediatR，實現CQRS模式，提高系統的可擴展性和鬆耦合性
- 使用Mapster進行物件映射，簡化資料轉換過程
- 整合FluentValidation進行輸入資料驗證，增強系統的安全性
- 加入ValidationBehavior到MediatR，確保請求的有效性
- 實現ExceptionHandler，提供良好的API錯誤處理機制，增強系統的穩定性
- 導入Carter用來整理MinamalAPI

*備註:
雖然目前使用了Generic Repository，但之後會根據實際情況進行調整和優化，以確保程式碼的簡潔和效能的最佳化。*


## 專案架構
- Messagequeue.Core:核心專案,會放入共用項目
- Messagequeue.Book:書本微服務
- Messagequeue.Cart:購物車微服務
- Messagequeue.Web:最終對外專案

## 設計模式
- Repository Pattern
- Cache Repository Pattern
- UnitOfWork
- CQRS

## 套件
- Redis
- Rabbit.Mq
- Nginx
- EF.Core
- Scrutor
- MediatR
- Mapster
- FluentValidation
- Carter
