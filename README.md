# Ioc Performance

[![Build Status](https://dev.azure.com/danielpalme/IocPerformance/_apis/build/status/danielpalme.IocPerformance?branchName=master)](https://dev.azure.com/danielpalme/IocPerformance/_build/latest?definitionId=6&branchName=master)

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](https://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](https://www.palmmedia.de)  
Twitter: [@danielpalme](https://twitter.com/danielpalme)  

## Results
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|41<br/>49|49<br/>59|69<br/>76|99<br/>103|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|26<br/>43|**33**<br/>**56**|51<br/>82|67<br/>**78**|
|**[Autofac 4.9.4](https://github.com/autofac/Autofac)**|593<br/>389|754<br/>504|1953<br/>1191|5877<br/>3609|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.11.2](http://www.catelproject.com)**|262<br/>308|4283<br/>4695|9693<br/>10646|22248<br/>24653|
|**[DryIoc 4.0.7](https://bitbucket.org/dadhi/dryioc)**|36<br/>49|56<br/>79|57<br/>102|76<br/>89|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 7.1.0](https://github.com/ipjohnson/Grace)**|26<br/>42|36<br/>62|55<br/>83|67<br/>83|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|300<br/>205|318<br/>226|719<br/>476|2004<br/>1228|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|58<br/>68|70<br/>103|99<br/>121|119<br/>138|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 6.2.0](https://github.com/seesharper/LightInject)**|30<br/>47|37<br/>66|56<br/>89|78<br/>88|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|365<br/>254|302<br/>211|540<br/>390|1493<br/>979|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|294<br/>226|294<br/>206|357<br/>252|677<br/>462|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25<br/>**39**|34<br/>59|55<br/>**77**|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 3.0.0](https://github.com/aspnet/Extensions)**|85<br/>84|108<br/>101|128<br/>124|143<br/>129|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|9074<br/>4916|13891<br/>9399|19760<br/>14962|57910<br/>51972|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[MvvmCross 6.4.1](https://github.com/MvvmCross/MvvmCross)**|254<br/>288|1326<br/>1426|3440<br/>3721|10322<br/>9997|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|91<br/>98|120<br/>93|174<br/>147|303<br/>231|
|**[SimpleInjector 4.7.1](https://simpleinjector.org)**|80<br/>77|96<br/>93|128<br/>121|169<br/>144|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|**24**<br/>45|38<br/>61|**50**<br/>88|**65**<br/>82|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.8.5](https://github.com/z4kn4fein/stashbox)**|39<br/>55|46<br/>68|65<br/>92|90<br/>112|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.11.1](https://github.com/unitycontainer/unity)**|231<br/>160|1598<br/>926|3599<br/>1995|8365<br/>4647|
|**[Windsor 5.0.1](http://castleproject.org)**|454<br/>342|1796<br/>1092|5618<br/>3523|16853<br/>10289|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>**75**|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|799<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.9.4](https://github.com/autofac/Autofac)**|6070<br/>3626|2243<br/>1377|7838<br/>4615|1445<br/>901|84497*<br/>53089|35800<br/>21902|22852<br/>14654|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.11.2](http://www.catelproject.com)**|<br/>|9585<br/>10434|<br/>|<br/>|<br/>|<br/>|4295<br/>4634|
|**[DryIoc 4.0.7](https://bitbucket.org/dadhi/dryioc)**|122<br/>123|58<br/>83|326<br/>232|58<br/>78|<br/>|1842<br/>1358|838<br/>540|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 7.1.0](https://github.com/ipjohnson/Grace)**|104<br/>116|**49**<br/>87|291<br/>215|**47**<br/>**70**|54478<br/>32637|868<br/>680|1151<br/>689|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|**774**<br/>**509**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|74<br/>89|86<br/>127|555<br/>410|<br/>|<br/>|1623<br/>1581|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 6.2.0](https://github.com/seesharper/LightInject)**|116<br/>122|53<br/>77|300<br/>225|350<br/>252|<br/>|2291<br/>1627|1496<br/>923|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|3200<br/>2005|385<br/>286|1303<br/>837|<br/>|<br/>|8309<br/>5461|5776<br/>3311|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1360<br/>881|294<br/>212|1368<br/>839|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 3.0.0](https://github.com/aspnet/Extensions)**|<br/>|124<br/>114|361<br/>265|<br/>|<br/>|3020<br/>1967|<br/>|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|44285<br/>31830|<br/>|42023<br/>35658|<br/>|<br/>|<br/>|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|**4370**<br/>**3103**|<br/>|<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[MvvmCross 6.4.1](https://github.com/MvvmCross/MvvmCross)**|1338<br/>1437|7389<br/>8213|<br/>|<br/>|5302<br/>3460|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|454<br/>360|139<br/>156|490<br/>354|<br/>|6570200*<br/>4095208*|59211<br/>33867|<br/>|
|**[SimpleInjector 4.7.1](https://simpleinjector.org)**|255<br/>246|123<br/>111|1390<br/>838|78<br/>79|<br/>|<br/>|7219<br/>4205|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|<br/>|**49**<br/>**75**|292<br/>220|<br/>|<br/>|**507**<br/>**555**|<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.8.5](https://github.com/z4kn4fein/stashbox)**|142<br/>140|67<br/>90|358<br/>336|65<br/>85|203135*<br/>120429*|1700<br/>1611|840<br/>543|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|65269*<br/>41725|7859<br/>4464|
|**[Unity 5.11.1](https://github.com/unitycontainer/unity)**|8560<br/>4885|9191<br/>5255|15421<br/>8702|3319<br/>1861|119255*<br/>70861*|54284<br/>39245|50324<br/>27704|
|**[Windsor 5.0.1](http://castleproject.org)**|34532<br/>19632|15140<br/>9111|15426<br/>9609|<br/>|226334*<br/>120937*|<br/>|13105<br/>7493|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|6327<br/>|6556<br/>|
|**[Autofac 4.9.4](https://github.com/autofac/Autofac)**|361<br/>|410<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.11.2](http://www.catelproject.com)**|100278*<br/>|100744*<br/>|
|**[DryIoc 4.0.7](https://bitbucket.org/dadhi/dryioc)**|76<br/>|83<br/>|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 7.1.0](https://github.com/ipjohnson/Grace)**|213<br/>|1128<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|8387<br/>|8960<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|1986<br/>|2373<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 6.2.0](https://github.com/seesharper/LightInject)**|114<br/>|821<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|141<br/>|148<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5313<br/>|6601<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 3.0.0](https://github.com/aspnet/Extensions)**|23<br/>|32<br/>|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|7904<br/>|8540<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[MvvmCross 6.4.1](https://github.com/MvvmCross/MvvmCross)**|10<br/>|16<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|12625<br/>|18413<br/>|
|**[SimpleInjector 4.7.1](https://simpleinjector.org)**|674<br/>|3185<br/>|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|27<br/>|443<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.8.5](https://github.com/z4kn4fein/stashbox)**|72<br/>|301<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.11.1](https://github.com/unitycontainer/unity)**|113<br/>|299<br/>|
|**[Windsor 5.0.1](http://castleproject.org)**|2912<br/>|2934<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|199<br/>|201<br/>|
### Charts
![Basic features](https://www.palmmedia.de/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](https://www.palmmedia.de/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](https://www.palmmedia.de/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
