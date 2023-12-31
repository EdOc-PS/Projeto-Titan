using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SystemVida : MonoBehaviour
{
    
    [Header("Health Settings")]
    public Sprite           coracaoCheio;
    public Sprite           coracaoEmpty;
    public Transform        ativarColuna2;
  
    public int             vida; //vida do player
  
    public int            vidamax; // qtde de corações na UI
   

    [Header("Health Quantidade")]
    public  Image[]         vidas;

    [Header("Invunerabilidade")]
    public SpriteRenderer   playerSprite;

    [Header("Morte")]
    public  Transform          desativarEspada;
    private Animator           playerAnimacao; 
    private Controller_Player  controleP;
    private Collider2D         coll2D;
   
    void Start(){
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimacao = GetComponent<Animator>();
        controleP = GetComponent<Controller_Player>();
        coll2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update(){
        QuantVida();
        DeathPlayer();
    }
    void QuantVida(){
        if(vida > vidamax){
            vida = vidamax;
        }
        if(vidamax > 5){
            ativarColuna2.gameObject.SetActive(true);
        }else{
            ativarColuna2.gameObject.SetActive(false);
        }
        for(int i = 0; i < vidas.Length; i++){
            if(i < vida){
                vidas[i].sprite = coracaoCheio;
            }else{
                vidas[i].sprite = coracaoEmpty;
            }
            if(i < vidamax){
                vidas[i].enabled = true;
            }else{
                vidas[i].enabled = false;
            }
        }
    }

    void DeathPlayer(){
        if(vida <= 0){
            controleP.enabled = false;
            coll2D.enabled = false;
            desativarEspada.gameObject.SetActive(false);
            playerAnimacao.SetTrigger("Death");        
        }
    }
    public IEnumerator DanoPlayer(){
        if( vida >= 1 ){
            for (int i = 0; i < 5; i++){
                playerSprite.color = new Color(.8f, .3f, .2f, .3f);
                yield return new WaitForSeconds(0.16f);
                playerSprite.color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(0.16f);
            }
        }
    }
    public void GanhaVida(){
        vida++;
    }
}
