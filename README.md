Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
<table>
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>
<tr><th>No</th><td>62</td><td>71</td><td>71</td><td>83</td></tr>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>743</td><td>536</td><td>1327</td><td>3910</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>346</td><td>317</td><td>901</td><td>3592</td></tr>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td>246</td><td>2393</td><td>6447</td><td>15885</td></tr>
<tr><th>DryIoc 1.1.1 (https://bitbucket.org/dadhi/dryioc)</th><th>42</th><th>43</th><th>51</th><th>77</th></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>80</td><td>105</td><td>161</td><td>562</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>104</td><td>124</td><td>213</td><td>257</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>101</td><td>104</td><td>250</td><td>658</td></tr>
<tr><th>Grace 2.0.0 (http://grace.codeplex.com)</th><td>224</td><td>246</td><td>426</td><td>1122</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>187</td><td>241</td><td>521</td><td>1370</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>83</td><td>86</td><td>105</td><td>136</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>115</td><td>111</td><td>126</td><td>160</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>123</td><td>128</td><td>177</td><td>216</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>307</td><td>2441</td><td>16965</td><td>88627</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>91</td><td>77</td><td>88</td><td>117</td></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>3021</td><td>12909</td><td>31644</td><td>85076</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>478</td><td>434</td><td>994</td><td>2848</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>20719</td><td>23668</td><td>39422</td><td>78903</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>162</td><td>474</td><td>1491</td><td>4301</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>512</td><td>596</td><td>1477</td><td>5283</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>69</td><td>139</td><td>360</td><td>1036</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>5911</td><td>12553</td><td>32792</td><td>91718</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>2876</td><td>2827</td><td>2961</td><td>4012</td></tr>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td>96</td><td>82</td><td>96</td><td>119</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1020</td><td>10122</td><td>24959</td><td>63512</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>1169</td><td>1187</td><td>3449</td><td>9371</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>394</td><td>365</td><td>536</td><td>1061</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>329</td><td>1508</td><td>4876</td><td>18923</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>2077</td><td>2845</td><td>7878</td><td>23778</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>545</td><td>1599</td><td>4805</td><td>12841</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>85</td><td>67</td><td>170</td><td>123</td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>3947</td><td>2805</td><td>3985</td><td></td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>4692</td><td></td><td>3727</td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td><td></td><td></td>
<tr><th>DryIoc 1.1.1 (https://bitbucket.org/dadhi/dryioc)</th><th>73</th><th>47</th><th>224</th><th>99</th>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>529</td><td></td><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>649</td><td></td><td></td><td></td>
<tr><th>Grace 2.0.0 (http://grace.codeplex.com)</th><td>1206</td><td>640</td><td>1677</td><td>976</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>724</td><td></td><td>981</td><td></td>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>1655</td><td></td><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>304</td><td>166</td><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>1724</td><td>10458</td><td>24914</td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>119</td><td>81</td><td>439</td><td>142</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>4738</td><td>750</td><td>4260</td><td>1742</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>81892</td><td>91131</td><td>60323</td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>6266</td><td>4731</td><td>4310</td><td>2371</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>884</td><td></td><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>82283</td><td>34385</td><td>69287</td><td>49096</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>3509</td><td></td><td></td><td></td>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td>157</td><td>81</td><td>583</td><td>289</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>60750</td><td></td><td></td><td></td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>10696</td><td>2698</td><td>11145</td><td></td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>1107</td><td>831</td><td>2117</td><td>1670</td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>2528</td><td>6975</td><td></td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>24293</td><td></td><td>38977</td><td></td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>25556</td><td>4325</td><td>13448</td><td></td>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>36500</td><td>18825</td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td></td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td>
<tr><th>DryIoc 1.1.1 (https://bitbucket.org/dadhi/dryioc)</th><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td></td><td></td>
<tr><th>Grace 2.0.0 (http://grace.codeplex.com)</th><th>5300</th><td>4794</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td></td><th>439</th>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td></td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td></td><td>806</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>1564100</td><td>5323</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td></td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>309900</td><td>18517</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>15054000</td><td>16752</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td></td><td></td>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td></td><td>5212</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td></td><td>40951</td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>279800</td><td>6106</td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td></td><td></td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>7600</td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>22500</td><td>65848</td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>88400</td><td>11115</td>
</table>
