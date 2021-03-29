using UnityEngine;
using TMPro;

public static class DisplayText
{
    private static TextMeshProUGUI m_uiText = null;
    private static TextMeshProUGUI m_oldUiText = null;
    private static string m_textToWrite = string.Empty;
    private static int m_characterIndex = 0;
    private static float m_timePerCharacter = 1f;
    private static float m_timer = 0;

    public static void AddText(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        m_oldUiText = m_uiText;
        m_uiText = uiText;
        m_textToWrite = textToWrite;
        m_timePerCharacter = timePerCharacter;
        m_characterIndex = 0;
        m_timer = 0f;

        Tick();
    }

    public static void Tick()
    {
        if (m_uiText == null)
            return;

        m_timer -= 1f * Time.deltaTime;

        if(m_timer <= 0f)
        {
            m_timer += m_timePerCharacter;
            m_characterIndex++;
            m_uiText.text = m_textToWrite.Substring(0, m_characterIndex);

            if (m_characterIndex >= m_textToWrite.Length)
            {
                Clear();
                return;
            }
        }
    }

    public static float GetTotalDuration()
    {
        return m_textToWrite.Length * m_timePerCharacter + 2;
    }

    public static void Clear()
    {
        if(m_oldUiText)
            m_oldUiText.text = string.Empty;
        
        if(m_uiText)
            m_uiText.text = string.Empty;
        
        m_textToWrite = string.Empty;
        m_uiText = null;
        m_oldUiText = null;

        m_timePerCharacter = 0f;
        m_characterIndex = 0;
        m_timer = 0f;
    }
}