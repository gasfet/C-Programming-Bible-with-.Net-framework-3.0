<?xml version="1.0" encoding="euc-kr" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:template match="/">
<html>
<head> <title> XSL를 이용한 데이터 출력  </title></head>
<body>
<h1> 앨범 소개 </h1>
<xsl:for-each select="songType">
<p><font color="red" size="5"> 제목 : <xsl:value-of select="title"/></font></p> 
<p><font color="blue" size="3"> 가수 : <xsl:value-of select="singer"/></font></p>
 발매년도 : <xsl:value-of select="year"/> 
<br></br>
</xsl:for-each>
</body>
</html>
</xsl:template>
</xsl:stylesheet> 