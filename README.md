# MessageQueue

## 目標
使用Docker叢集來建立微服務

測試RabbitMq相關功能

使用EF Code First+PostgreSql 來當Db
會使用Repository處理Db溝通
額外在使用Scrutor裝飾上CacheRepository
最後包在UnitOfWork做統一管理
雖然有使用Generic Repository,感覺這個有點多餘了
之後再看使用情形


## 專案架構
- Messagequeue.Core:核心專案,會放入共用項目
- Messagequeue.Book:書本微服務
- Messagequeue.Cart:購物車微服務
- Messagequeue.Web:最終對外專案

## 設計模式
- Repository Pattern
- Cache Repository Pattern
- UnitOfWork


## 套件
- Redis
- Rabbit.Mq
- Nginx
- EF.Core
- Scrutor
