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
**_*_**: Benchmark was stopped after 3 minutes and result is extrapolated.  
**OoM**: Benchmark was stopped after an *OutOfMemoryException* was thrown.  
**Error**: Benchmark was stopped after an *Exception* was thrown.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|108<br/>78|126<br/>116|147<br/>168|222<br/>206|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|893<br/>723|2568<br/>2571|6407<br/>4071|18191<br/>11244|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|538<br/>353|670<br/>405|1867<br/>1085|7969<br/>4632|
|**[Catel 3.9.0](http://www.catelproject.com)**|351<br/>431|4361<br/>4901|13210<br/>14088|32621<br/>36346|
|**[DryIoc 1.3.1](https://bitbucket.org/dadhi/dryioc)**|**37**<br/>**52**|**48**<br/>**60**|**64**<br/>**73**|**98**<br/>**97**|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|105<br/>80|134<br/>103|234<br/>162|823<br/>493|
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|105<br/>81|143<br/>120|194<br/>143|295<br/>203|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|149<br/>111|181<br/>132|451<br/>338|1327<br/>852|
|**[Grace 2.3.10](https://github.com/ipjohnson/Grace)**|174<br/>134|311<br/>225|787<br/>527|2002<br/>2244|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|374<br/>231|377<br/>243|971<br/>573|2813<br/>1548|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|91<br/>76|110<br/>95|122<br/>87|222<br/>194|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|207<br/>140|209<br/>146|219<br/>154|290<br/>199|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|108<br/>86|144<br/>115|180<br/>142|233<br/>166|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|203<br/>171|3364<br/>1998|34315<br/>34496|193101*<br/>205435*|
|**[LightInject 3.0.1.7](https://github.com/seesharper/LightInject)**|54<br/>59|80<br/>77|85<br/>83|123<br/>109|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|4163<br/>2443|24399<br/>16041|64412<br/>41898|170694<br/>104578|
|**[Maestro 1.4.0](https://github.com/JonasSamuelsson/Maestro)**|306<br/>243|461<br/>325|1199<br/>766|3443<br/>2124|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|34967<br/>19746|53521<br/>31946|87598<br/>65396|175864<br/>169289|
|**[Mef2 1.0.27.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|295<br/>201|290<br/>204|379<br/>439|633<br/>403|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|566<br/>303|818<br/>543|2901<br/>1802|8322<br/>8170|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|459<br/>359|810<br/>582|2380<br/>1666|9042<br/>6674|
|**[Munq 3.1.6](http://munq.codeplex.com)**|111<br/>79|283<br/>192|751<br/>454|2389<br/>1482|
|**[Ninject 3.2.2.0](http://ninject.org)**|7259<br/>4486|24276<br/>15296|69214<br/>39610|191033*<br/>117563|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6626<br/>4071|5546<br/>3373|6971<br/>4657|8246<br/>6118|
|**[SimpleInjector 2.5.2](https://simpleinjector.org)**|64<br/>64|92<br/>79|116<br/>95|149<br/>121|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|1046<br/>808|16566<br/>10128|45510<br/>29798|117230<br/>75645|
|**[StructureMap 3.1.0.133](http://structuremap.net/structuremap)**|2835<br/>2938|2748<br/>6505|11154<br/>10107|29225<br/>27277|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|656<br/>454|543<br/>383|833<br/>527|2170<br/>2363|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|421<br/>323|2705<br/>1698|13719<br/>6623|44567<br/>28659|
|**[Unity 3.5.1404.0](http://msdn.microsoft.com/unity)**|2873<br/>3812|7182<br/>3038|15294<br/>8012|39116<br/>21296|
|**[Windsor 3.3.0](http://castleproject.org)**|519<br/>383|2626<br/>3658|8893<br/>4861|26098<br/>16700|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|--------------------------:|
|**No**|348<br/>176|107<br/>106|275<br/>177|214<br/>180|1899<br/>524|88<br/>106|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|32706<br/>20892|5158<br/>3346|17288<br/>12199|<br/>|108964<br/>86101|51505<br/>37712|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|10427<br/>6064|<br/>|7758<br/>4514|<br/>|<br/>|<br/>|
|**[Catel 3.9.0](http://www.catelproject.com)**|<br/>|12293<br/>13237|<br/>|<br/>|<br/>|4411<br/>4783|
|**[DryIoc 1.3.1](https://bitbucket.org/dadhi/dryioc)**|**96**<br/>**94**|**61**<br/>**67**|**310**<br/>**227**|**76**<br/>**71**|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|855<br/>519|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1299<br/>789|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 2.3.10](https://github.com/ipjohnson/Grace)**|5426<br/>1946|981<br/>588|4315<br/>2458|1145<br/>667|20489<br/>12160|11619<br/>5261|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|1119<br/>697|<br/>|2252<br/>1373|<br/>|<br/>|**868**<br/>**538**|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|3104<br/>1931|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|385<br/>269|170<br/>131|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2487<br/>1843|23120<br/>15653|52456<br/>31250|<br/>|<br/>|<br/>|
|**[LightInject 3.0.1.7](https://github.com/seesharper/LightInject)**|119<br/>104|79<br/>82|368<br/>262|100<br/>81|<br/>|1647<br/>1079|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.4.0](https://github.com/JonasSamuelsson/Maestro)**|6693<br/>2348|718<br/>500|3933<br/>2431|1007<br/>644|<br/>|9134<br/>5777|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|180329*<br/>178984|198621*<br/>151746|137126<br/>140873|<br/>|<br/>|<br/>|
|**[Mef2 1.0.27.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1383<br/>887|313<br/>228|2587<br/>2518|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|11883<br/>7521|71914<br/>76734|6944<br/>7444|2060<br/>1369|706941*<br/>OoM|5051527*<br/>Error|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1899<br/>1169|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|165177<br/>106569|67347<br/>42019|151450<br/>96672|53576<br/>31926|45724250*<br/>37677615*|36162<br/>22413|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6297<br/>3789|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[SimpleInjector 2.5.2](https://simpleinjector.org)**|248<br/>177|99<br/>85|905<br/>559|221<br/>157|<br/>|10422<br/>6055|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|103584<br/>66296|<br/>|<br/>|<br/>|<br/>|77502<br/>43561|
|**[StructureMap 3.1.0.133](http://structuremap.net/structuremap)**|24841<br/>34278|8163<br/>8027|25240<br/>21399|<br/>|4670179*<br/>2961095*|21209<br/>17507|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|2391<br/>1093|1407<br/>881|3703<br/>4850|1598<br/>965|<br/>|<br/>|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|5275<br/>5538|<br/>|<br/>|<br/>|**17576**<br/>**11517**|<br/>|
|**[Unity 3.5.1404.0](http://msdn.microsoft.com/unity)**|40234<br/>21537|<br/>|65395<br/>41530|<br/>|53041<br/>31885|128682<br/>82599|
|**[Windsor 3.3.0](http://castleproject.org)**|52083<br/>32659|27157<br/>17004|26641<br/>13537|<br/>|340330*<br/>Error|21772<br/>13042|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
