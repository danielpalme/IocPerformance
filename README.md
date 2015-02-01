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
|**[Catel 4.0.0](http://www.catelproject.com)**|339<br/>408|5262<br/>6654|13926<br/>16622|36149<br/>39037|
|**[DryIoc 1.4.1](https://bitbucket.org/dadhi/dryioc)**|**31**<br/>**48**|**42**<br/>**57**|**56**<br/>83|**92**<br/>**81**|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|105<br/>80|134<br/>103|234<br/>162|823<br/>493|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|75<br/>68|134<br/>112|280<br/>204|680<br/>428|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|149<br/>111|181<br/>132|451<br/>338|1327<br/>852|
|**[Grace 2.4.2](https://github.com/ipjohnson/Grace)**|188<br/>127|303<br/>294|907<br/>926|2061<br/>1291|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|374<br/>231|377<br/>243|971<br/>573|2813<br/>1548|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|91<br/>76|110<br/>95|122<br/>87|222<br/>194|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|207<br/>140|209<br/>146|219<br/>154|290<br/>199|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|108<br/>86|144<br/>115|180<br/>142|233<br/>166|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|203<br/>171|3364<br/>1998|34315<br/>34496|193101*<br/>205435*|
|**[LightInject 3.0.2.3](https://github.com/seesharper/LightInject)**|36<br/>**48**|47<br/>**57**|66<br/>**68**|98<br/>83|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|4163<br/>2443|24399<br/>16041|64412<br/>41898|170694<br/>104578|
|**[Maestro 1.5.2](https://github.com/JonasSamuelsson/Maestro)**|323<br/>260|396<br/>301|1093<br/>725|3347<br/>2073|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|34967<br/>19746|53521<br/>31946|87598<br/>65396|175864<br/>169289|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|252<br/>179|263<br/>187|328<br/>250|559<br/>481|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|566<br/>303|818<br/>543|2901<br/>1802|8322<br/>8170|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|459<br/>359|810<br/>582|2380<br/>1666|9042<br/>6674|
|**[Munq 3.1.6](http://munq.codeplex.com)**|111<br/>79|283<br/>192|751<br/>454|2389<br/>1482|
|**[Ninject 3.2.2.0](http://ninject.org)**|7259<br/>4486|24276<br/>15296|69214<br/>39610|191033*<br/>117563|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6626<br/>4071|5546<br/>3373|6971<br/>4657|8246<br/>6118|
|**[QuickInject 1.0.0.12](https://github.com/isabgol/QuickInject)**|180<br/>173|198<br/>169|295<br/>259|671<br/>637|
|**[SimpleInjector 2.7.0](https://simpleinjector.org)**|78<br/>66|111<br/>135|382<br/>123|387<br/>132|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|1046<br/>808|16566<br/>10128|45510<br/>29798|117230<br/>75645|
|**[StructureMap 3.1.4.143](http://structuremap.net/structuremap)**|2531<br/>2831|2787<br/>2845|8181<br/>8274|19198<br/>20205|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|656<br/>454|543<br/>383|833<br/>527|2170<br/>2363|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|454<br/>468|2123<br/>1548|8825<br/>6132|35707<br/>26670|
|**[Unity 3.5.1404.0](http://msdn.microsoft.com/unity)**|2873<br/>3812|7182<br/>3038|15294<br/>8012|39116<br/>21296|
|**[Windsor 3.3.0](http://castleproject.org)**|519<br/>383|2626<br/>3658|8893<br/>4861|26098<br/>16700|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception With Proxy**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|--------------------------:|-----------------------:|------------------------------------------:|
|**No**|348<br/>176|107<br/>106|275<br/>177|214<br/>180|1899<br/>524|88<br/>106|4<br/>|4<br/>|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|32706<br/>20892|5158<br/>3346|17288<br/>12199|<br/>|108964<br/>86101|51505<br/>37712|487<br/>|643<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|10427<br/>6064|<br/>|7758<br/>4514|<br/>|<br/>|<br/>|63<br/>|70<br/>|
|**[Catel 4.0.0](http://www.catelproject.com)**|<br/>|16803<br/>26672|<br/>|<br/>|<br/>|9122<br/>5947|14591<br/>|14952<br/>|
|**[DryIoc 1.4.1](https://bitbucket.org/dadhi/dryioc)**|97<br/>**87**|**64**<br/>70|318<br/>225|**68**<br/>**69**|<br/>|<br/>|45<br/>|22822<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|855<br/>519|<br/>|<br/>|<br/>|<br/>|<br/>|19090<br/>|18509<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|9324<br/>|8177<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1299<br/>789|<br/>|<br/>|<br/>|<br/>|<br/>|11<br/>|**14**<br/>|
|**[Grace 2.4.2](https://github.com/ipjohnson/Grace)**|2828<br/>1589|707<br/>467|2601<br/>1645|805<br/>536|17498<br/>10605|8723<br/>5580|122304<br/>|123571<br/>|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|12609<br/>|12089<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|1119<br/>697|<br/>|2252<br/>1373|<br/>|<br/>|**868**<br/>**538**|81766<br/>|83181<br/>|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|3104<br/>1931|<br/>|<br/>|<br/>|<br/>|<br/>|310074*<br/>|362562*<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|385<br/>269|170<br/>131|<br/>|<br/>|<br/>|<br/>|2101<br/>|2795<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2487<br/>1843|23120<br/>15653|52456<br/>31250|<br/>|<br/>|<br/>|233<br/>|247<br/>|
|**[LightInject 3.0.2.3](https://github.com/seesharper/LightInject)**|**93**<br/>**87**|70<br/>**67**|**313**<br/>**211**|75<br/>**69**|<br/>|1450<br/>949|245<br/>|972<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|140<br/>|538<br/>|
|**[Maestro 1.5.2](https://github.com/JonasSamuelsson/Maestro)**|3730<br/>2293|746<br/>530|3911<br/>2381|978<br/>662|<br/>|9146<br/>6220|241<br/>|1042<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|180329*<br/>178984|198621*<br/>151746|137126<br/>140873|<br/>|<br/>|<br/>|23<br/>|3054<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1388<br/>1099|347<br/>241|1759<br/>1379|<br/>|<br/>|<br/>|7330<br/>|11858<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|18<br/>|23<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|11883<br/>7521|71914<br/>76734|6944<br/>7444|2060<br/>1369|706941*<br/>OoM|5051527*<br/>Error|559<br/>|2378<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1899<br/>1169|<br/>|<br/>|<br/>|<br/>|<br/>|12084<br/>|12117<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|165177<br/>106569|67347<br/>42019|151450<br/>96672|53576<br/>31926|45724250*<br/>37677615*|36162<br/>22413|115051<br/>|157982<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6297<br/>3789|<br/>|<br/>|<br/>|<br/>|<br/>|25<br/>|49<br/>|
|**[QuickInject 1.0.0.12](https://github.com/isabgol/QuickInject)**|204<br/>182|<br/>|<br/>|<br/>|1280234*<br/>919692*|<br/>|55<br/>|1721<br/>|
|**[SimpleInjector 2.7.0](https://simpleinjector.org)**|256<br/>226|104<br/>89|941<br/>584|232<br/>256|<br/>|8713<br/>4704|259<br/>|898<br/>|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|103584<br/>66296|<br/>|<br/>|<br/>|<br/>|77502<br/>43561|**10**<br/>|35698<br/>|
|**[StructureMap 3.1.4.143](http://structuremap.net/structuremap)**|18987<br/>19486|5485<br/>8342|17175<br/>18164|<br/>|3921913*<br/>2703535*|18162<br/>12085|1071<br/>|10211<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|2391<br/>1093|1407<br/>881|3703<br/>4850|1598<br/>965|<br/>|<br/>|91820<br/>|85792<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|5062<br/>4660|<br/>|<br/>|<br/>|**15411**<br/>**9844**|<br/>|185<br/>|224<br/>|
|**[Unity 3.5.1404.0](http://msdn.microsoft.com/unity)**|40234<br/>21537|<br/>|65395<br/>41530|<br/>|53041<br/>31885|128682<br/>82599|1612<br/>|2584<br/>|
|**[Windsor 3.3.0](http://castleproject.org)**|52083<br/>32659|27157<br/>17004|26641<br/>13537|<br/>|340330*<br/>Error|21772<br/>13042|4141<br/>|4463<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
