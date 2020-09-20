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
|**[Catel 5.12.6](http://www.catelproject.com)**|437<br/>403|5340<br/>5392|10959<br/>14834|32267<br/>33134|
|**[DryIoc 4.2.1](https://github.com/dadhi/DryIoc)**|59<br/>72|74<br/>87|110<br/>125|119<br/>119|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[Grace 7.1.1](https://github.com/ipjohnson/Grace)**|32<br/>50|67<br/>75|67<br/>95|81<br/>97|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|58<br/>68|70<br/>103|99<br/>121|119<br/>138|
|**[LightInject 6.3.4](https://github.com/seesharper/LightInject)**|33<br/>77|62<br/>67|66<br/>86|77<br/>94|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|365<br/>254|302<br/>211|540<br/>390|1493<br/>979|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.35.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|244<br/>192|272<br/>195|392<br/>302|775<br/>478|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25<br/>**39**|34<br/>59|55<br/>**77**|92<br/>89|
|**[Microsoft Extensions DependencyInjection 3.1.5](https://github.com/aspnet/Extensions)**|123<br/>120|146<br/>125|169<br/>146|178<br/>160|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|9074<br/>4916|13891<br/>9399|19760<br/>14962|57910<br/>51972|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[MvvmCross 6.4.2](https://github.com/MvvmCross/MvvmCross)**|298<br/>373|1913<br/>2023|5057<br/>5345|14603<br/>13824|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|121<br/>100|137<br/>126|194<br/>171|328<br/>238|
|**[SimpleInjector 5.0.1](https://simpleinjector.org)**|90<br/>104|175<br/>144|148<br/>138|176<br/>166|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|**24**<br/>45|38<br/>61|**50**<br/>88|**65**<br/>82|
|**[SmartDi 1.4.1](https://github.com/z33bs/SmartDi)**|193<br/>144|348<br/>233|615<br/>374|2344<br/>1410|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 3.1.2](https://github.com/z4kn4fein/stashbox)**|37<br/>67|64<br/>84|91<br/>112|126<br/>139|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.11.7](https://github.com/unitycontainer/unity)**|304<br/>293|2100<br/>1609|5599<br/>5024|12654<br/>6870|
|**[Windsor 5.0.1](http://castleproject.org)**|454<br/>342|1796<br/>1092|5618<br/>3523|16853<br/>10289|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>**75**|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|799<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.9.4](https://github.com/autofac/Autofac)**|6070<br/>3626|2243<br/>1377|7838<br/>4615|1445<br/>901|84497*<br/>53089|35800<br/>21902|22852<br/>14654|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.12.6](http://www.catelproject.com)**|<br/>|13894<br/>13840|<br/>|<br/>|<br/>|<br/>|6178<br/>6095|
|**[DryIoc 4.2.1](https://github.com/dadhi/DryIoc)**|185<br/>156|97<br/>101|497<br/>312|99<br/>97|<br/>|2405<br/>1666|**1231**<br/>805|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 7.1.1](https://github.com/ipjohnson/Grace)**|143<br/>128|68<br/>92|348<br/>269|**56**<br/>**77**|75197*<br/>43091|945<br/>714|1289<br/>**767**|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|74<br/>89|86<br/>127|555<br/>410|<br/>|<br/>|1623<br/>1581|<br/>|
|**[LightInject 6.3.4](https://github.com/seesharper/LightInject)**|125<br/>124|59<br/>82|309<br/>293|391<br/>291|<br/>|2619<br/>1761|1604<br/>1070|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|3200<br/>2005|385<br/>286|1303<br/>837|<br/>|<br/>|8309<br/>5461|5776<br/>3311|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.35.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1571<br/>1031|317<br/>236|1509<br/>987|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 3.1.5](https://github.com/aspnet/Extensions)**|<br/>|155<br/>142|452<br/>339|<br/>|<br/>|4586<br/>2612|<br/>|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|44285<br/>31830|<br/>|42023<br/>35658|<br/>|<br/>|<br/>|<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|**4370**<br/>**3103**|<br/>|<br/>|
|**[MvvmCross 6.4.2](https://github.com/MvvmCross/MvvmCross)**|1978<br/>2260|13465<br/>12799|<br/>|<br/>|8062<br/>5573|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|520<br/>385|183<br/>145|669<br/>408|<br/>|9589857*<br/>5697265*|86587*<br/>56374|<br/>|
|**[SimpleInjector 5.0.1](https://simpleinjector.org)**|347<br/>250|121<br/>120|948<br/>665|124<br/>109|<br/>|<br/>|8357<br/>4889|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|<br/>|**49**<br/>**75**|292<br/>220|<br/>|<br/>|**507**<br/>**555**|<br/>|
|**[SmartDi 1.4.1](https://github.com/z33bs/SmartDi)**|246<br/>181|275<br/>203|675<br/>447|273<br/>191|574619*<br/>411964*|<br/>|<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 3.1.2](https://github.com/z4kn4fein/stashbox)**|216<br/>158|95<br/>108|392<br/>287|73<br/>99|316554*<br/>239829*|2063<br/>2277|1802<br/>927|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|65269*<br/>41725|7859<br/>4464|
|**[Unity 5.11.7](https://github.com/unitycontainer/unity)**|11602<br/>6706|13703<br/>8365|22157<br/>13621|4356<br/>2695|181682*<br/>111712*|88358*<br/>56587|79466*<br/>43384|
|**[Windsor 5.0.1](http://castleproject.org)**|34532<br/>19632|15140<br/>9111|15426<br/>9609|<br/>|226334*<br/>120937*|<br/>|13105<br/>7493|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|6327<br/>|6556<br/>|
|**[Autofac 4.9.4](https://github.com/autofac/Autofac)**|361<br/>|410<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.12.6](http://www.catelproject.com)**|15615<br/>|16801<br/>|
|**[DryIoc 4.2.1](https://github.com/dadhi/DryIoc)**|81<br/>|89<br/>|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[Grace 7.1.1](https://github.com/ipjohnson/Grace)**|266<br/>|1062<br/>|
|**[Lamar 3.1.0](https://jasperfx.github.io/lamar/)**|1986<br/>|2373<br/>|
|**[LightInject 6.3.4](https://github.com/seesharper/LightInject)**|112<br/>|775<br/>|
|**[Maestro 3.6.2](https://github.com/JonasSamuelsson/Maestro)**|141<br/>|148<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.35.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5847<br/>|7644<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[Microsoft Extensions DependencyInjection 3.1.5](https://github.com/aspnet/Extensions)**|27<br/>|44<br/>|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|7904<br/>|8540<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[MvvmCross 6.4.2](https://github.com/MvvmCross/MvvmCross)**|14<br/>|21<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|20835<br/>|27706<br/>|
|**[SimpleInjector 5.0.1](https://simpleinjector.org)**|989<br/>|5191<br/>|
|**[Singularity 0.14.0](https://github.com/Barsonax/Singularity)**|27<br/>|443<br/>|
|**[SmartDi 1.4.1](https://github.com/z33bs/SmartDi)**|69<br/>|843<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 3.1.2](https://github.com/z4kn4fein/stashbox)**|77<br/>|801<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.11.7](https://github.com/unitycontainer/unity)**|121<br/>|341<br/>|
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
