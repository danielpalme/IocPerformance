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
<tr><th>No</th><td>87</td><td>97</td><td>98</td><td>113</td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>1015</td><td>756</td><td>1831</td><td>5656</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>479</td><td>460</td><td>1280</td><td>5164</td></tr>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td>362</td><td>3787</td><td>9266</td><td>24599</td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>112</td><td>122</td><td>182</td><td>491</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>155</td><td>147</td><td>188</td><td>286</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>146</td><td>162</td><td>335</td><td>926</td></tr>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>349</td><td>330</td><td>604</td><td>1521</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>237</td><td>269</td><td>616</td><td>1665</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>114</td><td>131</td><td>135</td><td>183</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>157</td><td>149</td><td>175</td><td>221</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>115</td><td>145</td><td>149</td><td>210</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>521</td><td>3759</td><td>24810</td><td>128591</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>116</td><th>108</th><th>115</th><th>153</th></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>4477</td><td>19350</td><td>48735</td><td>131431</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>1340</td><td>1418</td><td>2225</td><td>4821</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>31955</td><td>36452</td><td>59394</td><td>116499</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>296</td><td>767</td><td>2303</td><td>6623</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>678</td><td>741</td><td>2109</td><td>7572</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><th>98</th><td>132</td><td>427</td><td>1408</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>8705</td><td>18937</td><td>48415</td><td>135742</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>7859</td><td>4979</td><td>4937</td><td>5205</td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>118</td><td>119</td><td>139</td><td>175</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1297</td><td>13247</td><td>32909</td><td>83610</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>1710</td><td>1774</td><td>5102</td><td>13723</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>576</td><td>478</td><td>720</td><td>1442</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>692</td><td>2488</td><td>7884</td><td>30402</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>2894</td><td>3888</td><td>11011</td><td>33901</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>891</td><td>2770</td><td>7654</td><td>20659</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>122</td><td>95</td><td>208</td><td>174</td><td></td><td></td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>5667</td><td>4019</td><td>5596</td><td></td><td>60800</td><td>27211</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>6735</td><td></td><td>5410</td><td></td><td></td><td></td></tr>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>672</td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>898</td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>1679</td><td>864</td><td>2308</td><td>1401</td><th>8400</th><td>6404</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>986</td><td></td><td>543</td><td></td><td></td><th>582</th></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>2273</td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>343</td><td>143</td><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>2721</td><td>15612</td><td>37877</td><td></td><td></td><td></td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>166</th><th>108</th><th>166</th><th>189</th><td></td><td>1158</td></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>8239</td><td>1862</td><td>7026</td><td>4274</td><td></td><td>8410</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>121140</td><td>140380</td><td>92890</td><td></td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>9648</td><td>6569</td><td>5967</td><td>3180</td><td></td><td>14841</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>1240</td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>126405</td><td>53253</td><td>106354</td><td>74965</td><td>26403400</td><td>25525</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>6630</td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>233</td><td>128</td><td>287</td><td>451</td><td></td><td>7950</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>78459</td><td></td><td></td><td></td><td></td><td>55837</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>16211</td><td>4147</td><td>18304</td><td></td><td>460300</td><td>8764</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>1652</td><td>1152</td><td>3003</td><td>2296</td><td></td><td></td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>4573</td><td>10990</td><td></td><td></td><td>12600</td><td></td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>34092</td><td></td><td>54427</td><td></td><td>33500</td><td>98285</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>42610</td><td>6547</td><td>21873</td><td></td><td>139000</td><td>16838</td></tr>
</table>
