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
<tr><th>No</th><td>84</td><td>97</td><td>96</td><td>108</td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>1232</td><td>894</td><td>1948</td><td>5713</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>607</td><td>510</td><td>1451</td><td>5675</td></tr>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td>371</td><td>3963</td><td>9965</td><td>25889</td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>106</td><td>120</td><td>184</td><td>502</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>185</td><td>144</td><td>194</td><td>359</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>150</td><td>166</td><td>341</td><td>947</td></tr>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>362</td><td>338</td><td>625</td><td>1614</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>217</td><td>250</td><td>602</td><td>1677</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>106</td><td>130</td><td>174</td><td>176</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>160</td><td>156</td><td>182</td><td>231</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>116</td><td>147</td><td>150</td><td>216</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>497</td><td>4186</td><td>26700</td><td>136882</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>117</td><th>108</th><th>118</th><th>156</th></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>4618</td><td>19572</td><td>48899</td><td>131848</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>630</td><td>650</td><td>1705</td><td>4851</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>31618</td><td>36927</td><td>61797</td><td>125118</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>297</td><td>840</td><td>2438</td><td>6932</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>735</td><td>831</td><td>2240</td><td>7762</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><th>98</th><td>154</td><td>502</td><td>1458</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>9884</td><td>20361</td><td>52753</td><td>147187</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>4575</td><td>6507</td><td>5846</td><td>9720</td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>116</td><td>129</td><td>145</td><td>189</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1563</td><td>15283</td><td>37444</td><td>94916</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>2087</td><td>2000</td><td>5807</td><td>15700</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>617</td><td>506</td><td>775</td><td>1525</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>610</td><td>2411</td><td>7715</td><td>29699</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>2964</td><td>3944</td><td>11331</td><td>34861</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>917</td><td>2904</td><td>7742</td><td>20713</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>123</td><td>90</td><td>221</td><td>164</td>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>5714</td><td>4514</td><td>5905</td><td></td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>7395</td><td></td><td>6304</td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>690</td><td></td><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>915</td><td></td><td></td><td></td>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>1751</td><td>881</td><td>2341</td><td>1450</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>989</td><td></td><td>532</td><td></td>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>2352</td><td></td><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>344</td><td>153</td><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>2866</td><td>16914</td><td>41673</td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>167</th><th>110</th><th>170</th><th>192</th>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>8236</td><td>1198</td><td>6949</td><td>2978</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>124279</td><td>143918</td><td>93583</td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>9958</td><td>6940</td><td>6378</td><td>3406</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>1313</td><td></td><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>134822</td><td>55521</td><td>109940</td><td>80706</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>8420</td><td></td><td></td><td></td>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>237</td><td>129</td><td>332</td><td>466</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>89399</td><td></td><td></td><td></td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>18365</td><td>4617</td><td>22524</td><td></td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>1754</td><td>1248</td><td>3313</td><td>2509</td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>4050</td><td>11200</td><td></td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>35058</td><td></td><td>55951</td><td></td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>41219</td><td>6803</td><td>22207</td><td></td>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>59500</td><td>29279</td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td></td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td></td><td></td>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><th>9100</th><td>6473</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td></td><th>582</th>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td></td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td></td><td>1158</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td></td><td>7803</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td></td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td></td><td>14743</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>26666100</td><td>26046</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td></td><td></td>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td></td><td>8309</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td></td><td>62458</td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>692500</td><td>9102</td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td></td><td></td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>12600</td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>37600</td><td>98632</td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>143800</td><td>17694</td>
</table>
