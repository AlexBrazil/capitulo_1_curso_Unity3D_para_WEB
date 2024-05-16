using UnityEngine;
using UnityEngine.UIElements;


public class ButtonSend : MonoBehaviour
{
    private TextField textField_name;
    private TextField textField_email;
    private TextField textField_senha;
    private Button sendButton;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument n�o encontrado no GameObject.");
            return;
        }
        textField_name = uiDocument.rootVisualElement.Q<TextField>("TextField_name");

        if (textField_name == null)
        {
            Debug.LogError("Campo n�o encontrado");
            return;
        }


        textField_email = uiDocument.rootVisualElement.Q<TextField>("TextField_email");
        textField_senha = uiDocument.rootVisualElement.Q<TextField>("TextField_senha");

        sendButton = uiDocument.rootVisualElement.Q<Button>("Button_Send");

        if (sendButton == null)
        {
            Debug.LogError("Bot�o n�o encontrado na �rvore de componentes da UI.");
            return;
        }


        sendButton.RegisterCallback<ClickEvent>(OnSendClicked);
    }

    void OnSendClicked(ClickEvent evt)
    {
        Debug.Log("Nome: " + textField_name.text);
        Debug.Log("E-mail: " + textField_email.text);
        Debug.Log("Senha: " + textField_senha.text);
        
        // Adiciona essa linha para parar a propaga��o do evento
        evt.StopPropagation();

    }

    void OnDestroy()
    {
        sendButton.UnregisterCallback<ClickEvent>(OnSendClicked);
    }
}


