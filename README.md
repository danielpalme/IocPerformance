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
<tr><th>No</th><td>141</td><td>157</td><td>159</td><td>190</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>154</th><th>137</th><th>156</th><th>198</th></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td>196</td><td>155</td><td>340</td><td>284</td><td></td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>213</th><th>142</th><th>215</th><th>256</th><th>1403</th></tr>
</table>
