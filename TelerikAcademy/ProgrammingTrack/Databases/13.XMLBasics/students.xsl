<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Student Class</h1>
  <table bgcolor="#E0E0E0" cellspacing="1">
    <tr bgcolor="#EEEEEE">
      <td><b>Name</b></td>
      <td><b>Sex</b></td>
      <td><b>Date of birth</b></td>
      <td><b>Phone</b></td>
      <td><b>E-mail</b></td>
      <td><b>Course</b></td>
      <td><b>Speciality</b></td>
      <td><b>Faculty number</b></td>
      <td><b>Enrollment date</b></td>
      <td><b>Exam Score</b></td>
      <td><b>Endorsements</b></td>
      <td><b>Exams</b></td>
    </tr>
	<xsl:for-each select="/studentClass/student">
      <tr bgcolor="white">
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="sex"/></td>
        <td><xsl:value-of select="dateOfBirth"/></td>
        <td><xsl:value-of select="phone"/></td>
        <td><xsl:value-of select="email"/></td>
        <td><xsl:value-of select="course"/></td>
        <td><xsl:value-of select="speciality"/></td>
        <td><xsl:value-of select="facultyNumber"/></td>
        <td><xsl:value-of select="enrollmentInfo/enrollmentDate"/></td>
        <td><xsl:value-of select="enrollmentInfo/examScore"/></td>
        <xsl:for-each select="teacherEndorsements">
              <td>
                <ul>
                  <xsl:for-each select="endorsement">
                    <li>
                      <xsl:value-of select="current()"/>
                    </li>
                  </xsl:for-each>
                </ul>
              </td>       
        </xsl:for-each>
        <xsl:for-each select="exams">
          <td>
            <ul>
              <xsl:for-each select="examName">
                <li>
                  <xsl:value-of select="current()"/>
                </li>
              </xsl:for-each>
            </ul>
          </td>
        </xsl:for-each>
      </tr>
	</xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>