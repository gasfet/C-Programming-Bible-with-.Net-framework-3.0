<?xml version="1.0" encoding="euc-kr" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:template match="/">
<html>
<head> <title> XSL�� �̿��� ������ ���  </title></head>
<body>
<h1> �ٹ� �Ұ� </h1>
<xsl:for-each select="songType">
<p><font color="red" size="5"> ���� : <xsl:value-of select="title"/></font></p> 
<p><font color="blue" size="3"> ���� : <xsl:value-of select="singer"/></font></p>
 �߸ų⵵ : <xsl:value-of select="year"/> 
<br></br>
</xsl:for-each>
</body>
</html>
</xsl:template>
</xsl:stylesheet> 