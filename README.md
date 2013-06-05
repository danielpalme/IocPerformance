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
<tr><th>No</th><td>151</td><td>151</td><td>151</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1391</td><td>2337</td><td>5983</td><td>41114</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>324</td><td>378</td><td>811</td><td></td></tr>
<tr><th>Catel 3.5</th><td>492</td><td>1444</td><td>3828</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>164</td><td>171</td><td>231</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>92</th><th>119</th><th>163</th><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>143</td><td>147</td><td>358</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>353</td><td>370</td><td>679</td><td></td></tr>
<tr><th>HaveBox 1.0.0</th><td>170</td><td>193</td><td>285</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>198</td><td>191</td><td>212</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>578</td><td>3614</td><td>18116</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>268</td><td>296</td><td>432</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>5884</td><td>22617</td><td>58787</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>6378</td><td>11030</td><td>30879</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>380</td><td>797</td><td>2565</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>520</td><td>690</td><td>1981</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>169</td><td>195</td><td>553</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>14095</td><td>24900</td><td>67535</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>151</td><td>163</td><td>391</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>153</td><td>159</td><td>181</td><th>687</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>2265</td><td>19733</td><td>48510</td><td>821</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1746</td><td>1876</td><td>5720</td><td>9629</td></tr>
<tr><th>TinyIOC 1.2</th><td>571</td><td>2170</td><td>8143</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3551</td><td>5000</td><td>14463</td><td>126375</td></tr>
<tr><th>Windsor 3.2.0</th><td>1073</td><td>2977</td><td>8677</td><td>21372</td></tr>
</table>
