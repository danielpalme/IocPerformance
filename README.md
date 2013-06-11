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
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Interception</th></tr>
<tr><th>No</th><td>91</td><td>95</td><td>95</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1128</td><td>1888</td><td>5041</td><td>37739</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>245</td><td>275</td><td>704</td><td></td></tr>
<tr><th>Catel 3.5</th><td>610</td><td>1950</td><td>5379</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>128</td><td>148</td><td>230</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>86</th><th>105</th><th>142</th><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>4562</td><td>4551</td><td>6333</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>278</td><td>302</td><td>614</td><td></td></tr>
<tr><th>HaveBox 1.1.0</th><td>127</td><td>168</td><td>233</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>167</td><td>157</td><td>189</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>455</td><td>3441</td><td>16881</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>244</td><td>255</td><td>480</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>5762</td><td>22360</td><td>57558</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>36966</td><td>41803</td><td>70431</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>268</td><td>651</td><td>2189</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>997</td><td>1282</td><td>3378</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>99</td><td>119</td><td>411</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>10927</td><td>21815</td><td>61253</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>5395</td><td>6020</td><td>5717</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>132</td><td>143</td><td>156</td><th>462</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1965</td><td>17536</td><td>42741</td><td>712</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1863</td><td>2022</td><td>6304</td><td>11979</td></tr>
<tr><th>TinyIOC 1.2</th><td>583</td><td>2415</td><td>8454</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3659</td><td>5190</td><td>14963</td><td>113036</td></tr>
<tr><th>Windsor 3.2.0</th><td>1351</td><td>3477</td><td>10281</td><td>23301</td></tr>
</table>
