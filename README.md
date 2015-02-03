Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
### Basic Features
|**Container**|**Singleton**|**Transient**|
|:------------|------------:|------------:|
|**No**|594<br/>966|840<br/>1264|
|**[LightInject 3.0.2.2](https://github.com/seesharper/LightInject)**|**317**<br/>**598**|**501**<br/>**862**|
|**[SimpleInjector 2.7.0](https://simpleinjector.org)**|654<br/>941|891<br/>1297|
|**[Windsor 3.3.0](http://castleproject.org)**|2293<br/>3634|8450<br/>12383|
### Advanced Features
|**Container**|
|:------------|
|**No**|
|**[LightInject 3.0.2.2](https://github.com/seesharper/LightInject)**|
|**[SimpleInjector 2.7.0](https://simpleinjector.org)**|
|**[Windsor 3.3.0](http://castleproject.org)**|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
