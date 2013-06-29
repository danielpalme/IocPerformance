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
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th>
<th>Complex</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td>163</td><td>212</td><td>237</td>
<td>272</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>501</td><td>626</td><td>1456</td>
<td>6123</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>14371</td><td>29362</td><td>79536</td>
<td>215313</td><td>79391</td><td>225525</td><td>124613</td><td>31102</td></tr>
<tr><th>SimpleInjector 2.2.3</th><th>175</th><th>246</th><th>267</th>
<th>338</th><th>281</th><td></td><td></td><th>548</th></tr>
<tr><th>StyleMVVM 3.0.3</th><td>884</td><td>828</td><td>1159</td>
<td>1923</td><td>1718</td><th>3720</th><th>3625</th><td></td></tr>
</table>

Note: the results above might not be acurate, this is still a work in progress (Most containers have not been implemented)