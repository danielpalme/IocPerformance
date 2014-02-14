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
<tr><th>No</th><td>82</td><td>94</td><td>94</td><td>108</td></tr>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>1959</td><td>1027</td><td>2033</td><td>5832</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>526</td><td>516</td><td>1356</td><td>5216</td></tr>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td>428</td><td>3797</td><td>9610</td><td>24598</td></tr>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><th>69</th><td>67</td><td>75</td><th>124</th></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>138</td><td>155</td><td>224</td><td>568</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>94</td><td>118</td><td>157</td><td>231</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>121</td><td>142</td><td>331</td><td>920</td></tr>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><td>385</td><td>376</td><td>681</td><td>2003</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>236</td><td>250</td><td>603</td><td>1811</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>166</td><td>128</td><td>160</td><td>221</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>161</td><td>155</td><td>188</td><td>233</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>119</td><td>140</td><td>143</td><td>205</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>505</td><td>3723</td><td>25831</td><td>135824</td></tr>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td>95</td><th>64</th><th>73</th><td>135</td></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>4918</td><td>20370</td><td>51022</td><td>138261</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>952</td><td>707</td><td>1486</td><td>4246</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>32458</td><td>37044</td><td>61086</td><td>120495</td></tr>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td>257</td><td>278</td><td>320</td><td>549</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>313</td><td>835</td><td>2311</td><td>6672</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>1328</td><td>1044</td><td>2483</td><td>8696</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>117</td><td>155</td><td>452</td><td>1480</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>9429</td><td>21250</td><td>52494</td><td>146125</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>4890</td><td>4398</td><td>4621</td><td>5416</td></tr>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td>369</td><td>191</td><td>219</td><td>236</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>2225</td><td>17028</td><td>37143</td><td>91469</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>2335</td><td>2350</td><td>5745</td><td>15168</td></tr>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td>796</td><td>778</td><td>1023</td><td>1849</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>630</td><td>2254</td><td>7982</td><td>30851</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>4922</td><td>5211</td><td>12968</td><td>37929</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>1328</td><td>3559</td><td>8090</td><td>19443</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th></tr>
<tr><th>No</th><td>116</td><td>91</td><td>233</td><td>167</td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>5817</td><td>5383</td><td>6595</td><td></td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>6810</td><td></td><td>5392</td><td></td>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td></td><td>9671</td><td></td><td></td>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><th>124</th><td>96</td><td>358</td><td>178</td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>753</td><td></td><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>925</td><td></td><td></td><td></td>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><td>2078</td><td>674</td><td>3234</td><td>1521</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>1007</td><td></td><td>1386</td><td></td>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>2374</td><td></td><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>341</td><td>148</td><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>2618</td><td>16472</td><td>39052</td><td></td>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td>126</td><th>67</th><th>357</th><th>151</th>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>7592</td><td>1100</td><td>8118</td><td>2780</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>128606</td><td>146204</td><td>94481</td><td></td>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td>1174</td><td>311</td><td>1598</td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>10644</td><td>7847</td><td>7607</td><td>3786</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>1281</td><td></td><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>133976</td><td>54915</td><td>117482</td><td>77675</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>5392</td><td></td><td></td><td></td>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td>454</td><td>164</td><td>1424</td><td>680</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>83693</td><td></td><td></td><td></td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>17834</td><td>4767</td><td>22365</td><td></td>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td>2094</td><td>1443</td><td>3859</td><td>3100</td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>4259</td><td>10833</td><td></td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>38559</td><td></td><td>65904</td><td></td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>41177</td><td>7216</td><td>20517</td><td></td>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>400</td><td>101</td>
<tr><th>Autofac 3.3.0 (http://code.google.com/p/autofac)</th><td>66500</td><td>30059</td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td></td><td></td>
<tr><th>Catel 3.9.0 (http://www.catelproject.com)</th><td></td><td>3881</td>
<tr><th>DryIoc 1.2.0 (https://bitbucket.org/dadhi/dryioc)</th><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td></td><td></td>
<tr><th>Grace 2.1.0 (https://github.com/ipjohnson/Grace)</th><th>10100</th><td>8471</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td></td><th>955</th>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td></td><td></td>
<tr><th>LightInject 3.0.1.3 (https://github.com/seesharper/LightInject)</th><td></td><td>1411</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>2591000</td><td>11713</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td></td><td></td>
<tr><th>Mef2 1.0.20.0 (http://blogs.msdn.com/b/bclteam/p/composition.aspx)</th><td></td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>461000</td><td>14730</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>26707100</td><td>30712</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td></td><td></td>
<tr><th>SimpleInjector 2.4.1 (http://simpleinjector.codeplex.com)</th><td></td><td>9605</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td></td><td>60933</td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>490800</td><td>13998</td>
<tr><th>StyleMVVM 3.1.5 (http://stylemvvm.codeplex.com)</th><td></td><td></td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>11500</td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>38800</td><td>101940</td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>142800</td><td>21224</td>
</table>
