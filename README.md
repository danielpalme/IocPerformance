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
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|54<br/>55|67<br/>70|86<br/>105|114<br/>122|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|44<br/>52|50<br/>71|70<br/>**84**|84<br/>96|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|**26**<br/>**45**|**42**<br/>69|**60**<br/>96|**69**<br/>**78**|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|46<br/>58|52<br/>**67**|65<br/>101|88<br/>89|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|211<br/>331|243<br/>129|425<br/>433|1424<br/>1791|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|49<br/>63|76<br/>85|93<br/>96|98<br/>105|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|143<br/>108|77<br/>79|193<br/>153|73<br/>85|<br/>|<br/>|87<br/>86|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|112<br/>108|**60**<br/>**77**|**325**<br/>222|51<br/>74|<br/>|<br/>|**932**<br/>**549**|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|**98**<br/>119|86<br/>97|423<br/>**219**|**43**<br/>**70**|<br/>|**656**<br/>**463**|974<br/>602|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|101<br/>**102**|76<br/>83|365<br/>232|563<br/>353|<br/>|2367<br/>1884|1547<br/>1038|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|<br/>|221<br/>174|952<br/>610|<br/>|<br/>|2048<br/>1825|<br/>|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|135<br/>123|73<br/>103|371<br/>229|65<br/>75|<br/>|957<br/>731|1151<br/>691|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|3<br/>|3<br/>|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|106<br/>|398<br/>|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|194<br/>|1146<br/>|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|155<br/>|938<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|**27**<br/>|**34**<br/>|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|106<br/>|464<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz  
**Memory**: 11.91GB
