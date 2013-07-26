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
<tr><th>No</th><td>94</td><td>95</td><td>101</td><td>112</td></tr>
<tr><th>AutoFac 3.1.1</th><td>1151</td><td>1714</td><td>4019</td><td>11023</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>357</td><td>352</td><td>994</td><td>3850</td></tr>
<tr><th>Catel 3.6</th><td>291</td><td>1746</td><td>4297</td><td>11427</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>92</td><td>107</td><td>165</td><td>437</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>106</td><td>131</td><td>172</td><td>257</td></tr>
<tr><th>Funq 1.0.0.0</th><td>3666</td><td>3596</td><td>4275</td><td>4364</td></tr>
<tr><th>Griffin 1.1.0</th><td>178</td><td>222</td><td>492</td><td>1364</td></tr>
<tr><th>HaveBox 1.3.0</th><th>82</th><th>98</th><th>107</th><th>145</th></tr>
<tr><th>Hiro 1.0.3</th><td>125</td><td>121</td><td>131</td><td>178</td></tr>
<tr><th>IfFastInjector 0.1</th><td>94</td><td>127</td><td>153</td><td>202</td></tr>
<tr><th>LightCore 1.5.1</th><td>427</td><td>3079</td><td>19474</td><td>97515</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>182</td><td>192</td><td>338</td><td>802</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>5592</td><td>25600</td><td>63805</td><td>172186</td></tr>
<tr><th>Mef 4.0.0.0</th><td>36964</td><td>43100</td><td>73544</td><td>139572</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>331</td><td>1119</td><td>3196</td><td>8706</td></tr>
<tr><th>Mugen 3.5.1</th><td>851</td><td>877</td><td>2197</td><td>8226</td></tr>
<tr><th>Munq 3.1.6</th><td>232</td><td>341</td><td>1076</td><td>3114</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>8669</td><td>18672</td><td>49950</td><td>138014</td></tr>
<tr><th>Petite 0.3.2</th><td>4893</td><td>4789</td><td>5004</td><td>6771</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>111</td><td>108</td><td>128</td><td>154</td></tr>
<tr><th>Spring.NET 1.3.2</th><td>1202</td><td>12797</td><td>30853</td><td>79371</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1806</td><td>1745</td><td>4788</td><td>12902</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>394</td><td>368</td><td>486</td><td>834</td></tr>
<tr><th>TinyIoC 1.2</th><td>425</td><td>2129</td><td>7464</td><td>28511</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2610</td><td>3512</td><td>10370</td><td>31511</td></tr>
<tr><th>Windsor 3.2.1</th><td>800</td><td>2287</td><td>6466</td><td>17324</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No </th><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.1.1</th><td>3153</td><td>9519</td><td></td><td>30578</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td></td><td>3991</td><td></td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td></td><td></td><td></td><td></td></tr>
<tr><th>IfFastInjector 0.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>12210</td><td>29847</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>159898</td><td>106808</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>7349</td><td>6861</td><td>3557</td><td>17418</td></tr>
<tr><th>Munq 3.1.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>55066</td><td>113996</td><td>77611</td><td>27743</td></tr>
<tr><th>Petite 0.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><th>108</th><th>260</th><th>379</th><th>8182</th></tr>
<tr><th>Spring.NET 1.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>3620</td><td>16363</td><td></td><td>8231</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>957</td><td>2287</td><td>1949</td><td></td></tr>
<tr><th>TinyIoC 1.2</th><td>10009</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td></td><td>48901</td><td></td><td>99258</td></tr>
<tr><th>Windsor 3.2.1</th><td>5345</td><td>17761</td><td></td><td>15769</td></tr>
</table>
