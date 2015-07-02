using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class PlatformerCharacter2D : MonoBehaviour
	{
		[SerializeField]
		private float
			m_MaxSpeed = 10f;					// Velocidade que ele corre
		[SerializeField]
		private float
			m_JumpForce = 400f;                  // Amount of force added when the player jumps.
		[SerializeField]
		private LayerMask
			m_WhatIsGround;                  // A mask determining what is ground to the character

		private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		public bool m_Grounded;            // Whether or not the player is grounded.
		private Animator m_Anim;            // Reference to the player's animator component.
		private Rigidbody2D m_Rigidbody2D;

		private bool play;				// Se pode jogar

		private void Awake ()
		{
			// Setting up references.
			play = true;
			m_GroundCheck = transform.Find ("GroundCheck");
			m_Anim = GetComponent<Animator> ();
			m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		}


		private void FixedUpdate ()
		{
			m_Grounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll (m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			for (int i = 0; i < colliders.Length; i++) {
				if (colliders [i].gameObject != gameObject)
					m_Grounded = true;
			}
			;
		}


		public void Move (float move, bool jump)
		{
			// Se pode jogar
			if (play) {
				//only control the player if grounded or airControl is turned on
				if (m_Grounded) {
					
					// Move the character
					m_Rigidbody2D.velocity = new Vector2 (move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
				}
				// If the player should jump...
				if (m_Grounded && jump) {
					// Add a vertical force to the player.
					m_Grounded = false;
					m_Anim.SetTrigger ("Jump"); //Pula
					m_Rigidbody2D.AddForce (new Vector2 (0f, m_JumpForce));
				}
			}
		}

		private void OnCollisionEnter2D (Collision2D other)
		{
			if (other.transform.tag == "Obstacle") {
				if (play) {
					play = false; // Nao pode mais jogar
					m_Anim.SetTrigger ("Die"); //Morre

					//TROCA A CENA AQUI
				}
			}
		}
	}
}
