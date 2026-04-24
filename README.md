# 🏰 Masmorra - Escape Room Unity

![Unity](https://img.shields.io/badge/Unity-2022.3+-black?logo=unity&logoColor=white)
![Language](https://img.shields.io/badge/Language-C%23-blue?logo=csharp&logoColor=white)
![Status](https://img.shields.io/badge/Status-Em_Desenvolvimento-orange)

Uma experiência de **Escape Room** em primeira pessoa desenvolvida no Unity. O jogador encontra-se preso numa masmorra medieval e deve explorar o ambiente, encontrar objetos escondidos e resolver puzzles lógicos para conseguir escapar.

---

## 🚀 Funcionalidades Principais

* **Sistema de Inventário Simples:** Recolha de chaves e itens essenciais para o progresso.
* **Lanterna e Tinta Invisível:** Utilização de uma lanterna para revelar números escondidos nas paredes (mecânica de luz UV).
* **Interação com Objetos:** Abertura de portas, baús e painéis de código com a tecla **E**.
* **Puzzles de Teclado (Keypads):** Introdução de códigos numéricos para desbloquear áreas e recompensas.
* **Atmosfera Imersiva:** Iluminação controlada e sons de interação (portas, chaves, lanterna).

---

## 🎮 Controlos

| Tecla | Ação |
| :--- | :--- |
| **W, A, S, D** | Movimentar o jogador |
| **Rato** | Olhar em redor / Mirar |
| **E** | Interagir (Pegar itens, Abrir baús/portas) |
| **F** | Ligar / Desligar Lanterna |
| **ESC** | Pausar / Sair |

---

## 🛠️ Detalhes Técnicos

### Scripts Principais
* `PlayerInteraction.cs`: Gere todos os disparos de raio (Raycast) para detetar e interagir com objetos no cenário.
* `TintaInvisivel.cs`: Controla a opacidade dos números secretos com base na distância e ângulo da lanterna.
* `MouseLook.cs` & `PlayerMovement.cs`: Controlos de câmara e movimento, com bloqueio automático da câmara quando o jogador interage com painéis de código.

---
### Como atualizar no GitHub:
1. Vai ao teu repositório no GitHub.
2. Clica no ficheiro `README.md`.
3. Clica no ícone do **lápis** (Edit) no canto superior direito.
4. Apaga o que lá está e cola este código novo.
5. Clica em **"Commit changes..."** no fundo da página para guardar.


### Trabalho realizado por:
1. 33400 Francisco Gomes.
2. 33157 Afonso Barbosa.

## 📂 Como Correr o Projeto

1. Faça o clone do repositório:
   ```bash
   git clone [https://github.com/franciscox05/Masmorra.git](https://github.com/franciscox05/Masmorra.git)
