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
<tr><th>No</th><td>58</td><td>67</td><td>66</td><td>76</td></tr>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>1401</td><td>742</td><td>1652</td><td>4695</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>334</td><td>300</td><td>846</td><td>3367</td></tr>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td>222</td><td>2570</td><td>6435</td><td>16343</td></tr>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><th>40</th><th>41</th><th>46</th><th>74</th></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>75</td><td>86</td><td>127</td><td>353</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>69</td><td>80</td><td>107</td><td>157</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>85</td><td>99</td><td>226</td><td>622</td></tr>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><td>231</td><td>194</td><td>394</td><td>1212</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>153</td><td>167</td><td>407</td><td>1122</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>78</td><td>84</td><td>109</td><td>145</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>110</td><td>106</td><td>127</td><td>156</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>84</td><td>99</td><td>108</td><td>140</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>302</td><td>2434</td><td>16110</td><td>83216</td></tr>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td>45</td><td>44</td><td>52</td><td>93</td></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>2874</td><td>12235</td><td>30456</td><td>81202</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>456</td><td>436</td><td>995</td><td>2564</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>20430</td><td>23545</td><td>39431</td><td>76723</td></tr>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td>158</td><td>157</td><td>195</td><td>329</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>183</td><td>528</td><td>1652</td><td>4702</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>689</td><td>596</td><td>1527</td><td>5552</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>67</td><td>93</td><td>282</td><td>946</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>5442</td><td>12696</td><td>31317</td><td>87282</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>3624</td><td>5318</td><td>3232</td><td>3744</td></tr>
<tr><th>SimpleInjector 2.5.0 (http://simpleinjector.codeplex.com)</th><td>225</td><td>98</td><td>147</td><td>151</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1280</td><td>10221</td><td>23201</td><td>57536</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>1270</td><td>1302</td><td>3515</td><td>9337</td></tr>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td>346</td><td>341</td><td>479</td><td>973</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>266</td><td>1524</td><td>4975</td><td>19133</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>2786</td><td>3077</td><td>7877</td><td>22995</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>721</td><td>2347</td><td>5223</td><td>12984</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th></tr>
<tr><th>No</th><td>82</td><td>64</td><td>158</td><td>118</td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>4655</td><td>3857</td><td>4779</td><td></td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>4394</td><td></td><td>3468</td><td></td>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td></td><td>6338</td><td></td><td></td>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><th>70</th><th>45</th><th>215</th><th>96</th>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>461</td><td></td><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>616</td><td></td><td></td><td></td>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><td>1263</td><td>367</td><td>2013</td><td>944</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>714</td><td></td><td>891</td><td></td>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>1559</td><td></td><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>231</td><td>96</td><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>1663</td><td>10152</td><td>24033</td><td></td>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td>83</td><td>46</td><td>227</td><td>103</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>4711</td><td>677</td><td>4827</td><td>1730</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>80742</td><td>93841</td><td>61153</td><td></td>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td>747</td><td>166</td><td>917</td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>6754</td><td>5328</td><td>4606</td><td>2330</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>834</td><td></td><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>80060</td><td>33939</td><td>68419</td><td>47032</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>3733</td><td></td><td></td><td></td>
<tr><th>SimpleInjector 2.5.0 (http://simpleinjector.codeplex.com)</th><td>257</td><td>98</td><td>777</td><td>379</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>53751</td><td></td><td></td><td></td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>11087</td><td>2762</td><td>12061</td><td></td>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td>1075</td><td>807</td><td>2035</td><td>1573</td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>2556</td><td>6874</td><td></td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>23326</td><td></td><td>38926</td><td></td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>26630</td><td>4942</td><td>13970</td><td></td>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>200</td><td>71</td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>38900</td><td>20369</td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td></td><td></td>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td></td><td>2557</td>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td></td><td></td>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><td>6300</td><td>5477</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td></td><th>552</th>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td></td><td></td>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td></td><td>825</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>1545100</td><td>6882</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td></td><td></td>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td></td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>290900</td><td>11203</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>14214700</td><td>17703</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td></td><td></td>
<tr><th>SimpleInjector 2.5.0 (http://simpleinjector.codeplex.com)</th><th>700</th><td>6005</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td></td><td>37913</td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>279400</td><td>8468</td>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td></td><td></td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>7700</td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>22900</td><td>62978</td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>87800</td><td>13205</td>
</table>
