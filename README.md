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
**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|42<br/>37|51<br/>88|53<br/>66|70<br/>116|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|**22**<br/>**29**|**33**<br/>50|**37**<br/>**51**|**51**<br/>**55**|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|526<br/>333|772<br/>458|1944<br/>1153|6144<br/>3410|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|346<br/>240|425<br/>251|1271<br/>791|5612<br/>2984|
|**[Catel 5.10.0](http://www.catelproject.com)**|208<br/>261|3918<br/>4120|9513<br/>9771|22267<br/>22334|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|44<br/>38|55<br/>47|78<br/>69|183<br/>122|
|**[DryIoc 4.0.4](https://bitbucket.org/dadhi/dryioc)**|37<br/>36|46<br/>47|62<br/>65|71<br/>64|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|91<br/>65|70<br/>57|69<br/>77|190<br/>128|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|52<br/>45|78<br/>62|134<br/>102|426<br/>261|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|57<br/>47|94<br/>78|175<br/>116|401<br/>235|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|110<br/>78|124<br/>141|365<br/>219|1030<br/>681|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|27<br/>47|34<br/>**36**|38<br/>157|**51**<br/>56|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|276<br/>189|239<br/>172|636<br/>553|1877<br/>1154|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|53<br/>50|58<br/>105|66<br/>60|106<br/>127|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|55<br/>66|94<br/>74|109<br/>145|154<br/>114|
|**[Lamar 3.0.2](https://jasperfx.github.io/lamar/)**|46<br/>60|70<br/>58|65<br/>241|99<br/>107|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|127<br/>293|2444<br/>1334|30450<br/>33714|178958*<br/>192402*|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|35<br/>70|42<br/>44|51<br/>108|72<br/>61|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3080<br/>1649|17547<br/>17794|45436<br/>46731|116087*<br/>82685*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|294<br/>217|370<br/>250|887<br/>555|2784<br/>1534|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|20907<br/>11217|33951<br/>20204|58139<br/>37056|113148*<br/>114653*|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|182<br/>124|195<br/>136|280<br/>171|530<br/>316|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|26<br/>48|42<br/>46|53<br/>145|82<br/>67|
|**[MicroSliver 2.1.6](  )**|147<br/>173|756<br/>518|2463<br/>1298|7202<br/>4009|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|66<br/>53|95<br/>141|111<br/>79|167<br/>192|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|453<br/>559|716<br/>482|2109<br/>2512|7778<br/>5890|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|77<br/>107|326<br/>800|2192<br/>1383|10196<br/>6255|
|**[Munq 3.1.6](http://munq.codeplex.com)**|66<br/>76|108<br/>81|393<br/>302|1268<br/>704|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|176<br/>191|1120<br/>1118|3063<br/>3068|8419<br/>8540|
|**[Ninject 3.3.4](http://ninject.org)**|2638<br/>1807|7770<br/>5857|32191<br/>15504|71494*<br/>47576|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|174<br/>134|196<br/>155|232<br/>192|361<br/>233|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|51<br/>51|79<br/>140|93<br/>75|125<br/>141|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|30<br/>33|35<br/>47|40<br/>60|63<br/>67|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|735<br/>476|9869<br/>8378|28958<br/>26765|76190*<br/>52065|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|39<br/>58|50<br/>54|57<br/>65|79<br/>76|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1190<br/>813|1464<br/>961|3494<br/>2208|8855<br/>6091|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|269<br/>193|470<br/>305|1272<br/>820|3819<br/>2260|
|**[Windsor 5.0.0](http://castleproject.org)**|425<br/>309|2268<br/>1476|7306<br/>4221|21814<br/>11710|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|457<br/>370|1508<br/>911|4025<br/>2437|11468<br/>6727|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|98<br/>82|59<br/>105|155<br/>149|56<br/>143|532<br/>438|<br/>|382<br/>279|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|770<br/>414|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|6105<br/>3381|2187<br/>1270|8663<br/>4755|1575<br/>918|80072*<br/>45459|32858<br/>20274|22159<br/>11516|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|7455<br/>3804|<br/>|6364<br/>3359|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.10.0](http://www.catelproject.com)**|<br/>|9358<br/>9918|<br/>|<br/>|<br/>|<br/>|3869<br/>4109|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|59<br/>**65**|77<br/>66|374<br/>236|<br/>|<br/>|<br/>|**56**<br/>**51**|
|**[DryIoc 4.0.4](https://bitbucket.org/dadhi/dryioc)**|106<br/>99|65<br/>59|239<br/>167|58<br/>58|<br/>|1890<br/>1241|838<br/>463|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|269<br/>172|69<br/>64|240<br/>164|362<br/>222|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|576<br/>335|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1133<br/>623|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|83<br/>111|**39**<br/>52|235<br/>229|**36**<br/>**43**|49514<br/>29928|**570**<br/>**643**|893<br/>496|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|857<br/>461|<br/>|1746<br/>1132|<br/>|<br/>|<br/>|737<br/>455|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|281<br/>277|107<br/>87|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Lamar 3.0.2](https://jasperfx.github.io/lamar/)**|75<br/>108|67<br/>73|481<br/>Error|<br/>|<br/>|1437<br/>1212|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|1856<br/>2844|18397<br/>16367|40549<br/>25238|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|107<br/>138|49<br/>55|**226**<br/>209|303<br/>187|<br/>|13189<br/>7538|1427<br/>1027|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3155<br/>2130|635<br/>388|3610<br/>2191|909<br/>568|<br/>|<br/>|6461<br/>3450|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|121933*<br/>129641*|129749*<br/>94384*|92489*<br/>91938*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1315<br/>748|230<br/>156|1344<br/>761|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**45**<br/>80|<br/>|**226**<br/>**154**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|<br/>|112<br/>101|348<br/>268|<br/>|<br/>|2502<br/>1412|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10301<br/>6315|58471<br/>57169|6006<br/>8411|1582<br/>1331|517775*<br/>363974*|<br/>|12263<br/>8765|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|341<br/>1002|<br/>|9710<br/>5639|<br/>|4793<br/>**2613**|<br/>|<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1183<br/>775|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|1132<br/>1172|7420<br/>7161|<br/>|<br/>|**4774**<br/>2908|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|66061*<br/>53769|24308<br/>17812|80540*<br/>61469*|20417<br/>14621|42102000*<br/>24497960*|<br/>|18517<br/>15740|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|516<br/>335|214<br/>161|10853<br/>5623|<br/>|17285750*<br/>8907836*|97430*<br/>52903|<br/>|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|215<br/>149|90<br/>129|744<br/>427|86<br/>114|<br/>|<br/>|7353<br/>4047|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|<br/>|45<br/>**50**|329<br/>223|<br/>|<br/>|1956<br/>1292|<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|54741<br/>49702|<br/>|<br/>|<br/>|<br/>|<br/>|47593<br/>40797|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|112<br/>109|60<br/>60|266<br/>192|60<br/>58|198221*<br/>109277*|1391<br/>1556|919<br/>598|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8894<br/>5951|2506<br/>1588|9205<br/>5512|<br/>|2805454*<br/>1504890*|76327*<br/>46214|7942<br/>4961|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|3908<br/>2555|1335<br/>766|5380<br/>3273|974<br/>605|7780<br/>7307|35846<br/>30828|<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|40729<br/>22399|16363<br/>9291|19106<br/>10249|<br/>|222018*<br/>124993*|<br/>|13614<br/>8176|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|16593<br/>9376|7999<br/>4384|17272<br/>10390|3447<br/>1937|24770<br/>15500|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|1<br/>|1<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|5228<br/>|5208<br/>|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|339<br/>|392<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|45<br/>|50<br/>|
|**[Catel 5.10.0](http://www.catelproject.com)**|57329<br/>|57339<br/>|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|**0**<br/>|**0**<br/>|
|**[DryIoc 4.0.4](https://bitbucket.org/dadhi/dryioc)**|68<br/>|76<br/>|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**0**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16321<br/>|16372<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|7714<br/>|7750<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|7<br/>|8<br/>|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|156<br/>|927<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|9382<br/>|9395<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54791<br/>|55035<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1391<br/>|1926<br/>|
|**[Lamar 3.0.2](https://jasperfx.github.io/lamar/)**|2192<br/>|2500<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|207<br/>|223<br/>|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|187<br/>|845<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|102<br/>|316<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|181<br/>|821<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|14<br/>|2193<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5522<br/>|6723<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25108<br/>|59100<br/>|
|**[MicroSliver 2.1.6](  )**|8<br/>|14<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|21<br/>|29<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|376<br/>|1700<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|13<br/>|16<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|10354<br/>|10017<br/>|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|8<br/>|12<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|84360*<br/>|77702*<br/>|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|31249<br/>|40318<br/>|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|711<br/>|2863<br/>|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|81<br/>|582<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25896<br/>|25842<br/>|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|77<br/>|299<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1443<br/>|6509<br/>|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|84<br/>|88<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|2998<br/>|3028<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|182<br/>|194<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: AMD Ryzen Threadripper 1950X 16-Core Processor   
**Memory**: 63.88GB
