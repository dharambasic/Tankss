using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int brojIgraca = 1;  //  identifikacijski  broj  igrača public  float  brzina  =  12f;	//  brzina  kretanja  tenka
    public float brzinaOkreta = 180f;   //  brzina  skretanja  tenka  u  stupnjevima public  AudioSource  zvukKretanja;	//  referenca  na  izvor  zvuka
    public AudioClip zvukMotora;    //  referenca  na  zvuk public  AudioClip  zvukVoznje;	//  referenca  na  zvuk
    public float rasponZvuka = 0.2f;    //  raspon  u  kojem  će  zvuk  varirati


    private string osKretanja;  //  ime  ulazne  osi  za  kretanje  naprijed  i  natrag private  string  osSkretanja;		//  ime  zlazne  osi  za  skretanje
    private Rigidbody m_Rigidbody;  //  referenca  za  pomicanje  tenka
    private float ulaznaVrijednostKretanja;     //  trenutna  ulazna  vrijednost  za  kretanje private  float  ulaznaVrijednostSkretanja;	//  trenutna  ulazna  vrijednost  za  skretanje private  float  originalZvuk;		//  jačina  zvuka  na  početku


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();  //  postavljanje  reference



    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        //  reset  ulaznih  vrijednosti ulaznaVrijednostKretanja  =  0f; ulaznaVrijednostSkretanja  =  0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()    //funkcija  start  izvršava  se  na  početku
    {
        //imena  osi  bazirana  su  na  broju  igrača osKretanja  =  "Vertical"  +  brojIgraca; osSkretanja  =  "Horizontal"  +  brojIgraca;
        //Spremimo  jačinu  zvuka originalZvuk  =  zvukKretanja.pitch;
    }


    private void Update()
    {
        //  Spremamo  vrijednosti  obadviju  osi ulaznaVrijednostKretanja  =  Input.GetAxis(osKretanja); ulaznaVrijednostSkretanja  =  Input.GetAxis(osSkretanja);

        ZvukMotora();
    }


    private void ZvukMotora()
    {
        //  ako  nema  ulazne  vrijednosti  tenk  se  ne  miče if(Mathf.Abs(ulaznaVrijednostKretanja)<0.1f  &&  Mathf.Abs
       if ((ulaznaVrijednostSkretanja) < 0.1f)
{
            //  ako  svira  zvuk  vožnje  promijeniti  ga  u  zvuk  motora if(zvukKretanja.clip  ==  zvukVoznje){
            zvukKretanja.clip = zvukMotora;
            zvukKretanja.pitch = Random.Range(originalZvuk - rasponZvuka, originalZvuk + rasponZvuka);
            zvukKretanja.Play();


        }
else
{

        }



        //  ako  svira  zvuk  motora  promijeniti  ga  u  zvuk  vožnje if  (zvukKretanja.clip  ==  zvukMotora)
        {

            zvukKretanja.clip = zvukVoznje;



            zvukKretanja.pitch = Random.Range(originalZvuk - rasponZvuka, originalZvuk
            + rasponZvuka); zvukKretanja.Play();
        }
    }
}


    private void FixedUpdate()
{
    //  pokretanje  i  skretanje  tenka Kretanje();
    Skretanje();
}


    private void Kretanje()
{
    //  pokreni  tenk  unaprijed  ili  unatrag  ovisno  o  ulaznoj  vrijednosti  kretanja Vector3  movement  =  transform.forward  *  ulaznaVrijednostKretanja  *  brzina  *
    Time.deltaTime;
    //  primjeni  kretanje  na  tenk m_Rigidbody.MovePosition(m_Rigidbody.position  +  movement);
}


private void Skretanje()
{
    //  odredi  broj  stupnjeva  za  koje  će  se  tenk  rotirati  prema  ulaznoj  vrijednosti float  turn  =  ulaznaVrijednostSkretanja  *  brzinaOkreta  *  Time.deltaTime;

    //  rotiraj  samo  po  y  osi
    Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

    //  primjeni  rotaciju  na  tenk m_Rigidbody.MoveRotation(m_Rigidbody.rotation  *  turnRotation);
}


   
