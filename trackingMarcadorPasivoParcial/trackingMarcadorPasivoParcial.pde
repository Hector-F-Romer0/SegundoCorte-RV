/***
* El siguiente programa en processing permite hacerle tracking a dos Marcadores pasivos
* que tengan colores diferentes.
*/
// importa la librería video
import processing.video.*;
import processing.serial.*;
import processing.net.*;

//Instancio la variable para capturar la camara
Capture camara;
Server servidor;
String datosPosiciones = "";//Guarda la informacion que se enviara por el puerto.

// Instancio la variable del color que se va a buscar
color marcadorA;

int xMarcadorA = 0;
int yMarcadorA = 0;

// Distancia de semejanza en color
float semejanzaEnColor = 45;
float minimoDePixelesSemejantes = 50;

void settings() {
    // creo la ventana
    size(640, 480);
}

void setup()
{
    // Iniciar servidor en el puerto 5204
    servidor = new Server(this, 5204);

    // Habilitar solo para depurar el driver de la camara en caso de problemas detectando la camara
    //String[] cameras = Capture.list();
    //printArray(cameras);
    //camara = new Capture(this, cameras[3]);

    // Se crea un objeto que almacena la cámara del usuario, con una velocidad de fotogramas de 30.
    //camara = new Capture(this, width, height, 30);
    camara = new Capture(this, "pipeline:autovideosrc");
    camara.start();

    // Marcadores
    // color audifono : (167,151,147)
    marcadorA = color(156,12,12); // Color real del marcador A.
}

void draw()
{
    //verifica si la camara esta disponible
    if (camara.available())
    {
      //Versión espejo
        //camara.read();
        //image(camara,0,0);
        
        
        camara.read();
        // Envia la transformación que vamos a hacer (rotar la cámara en X) a la pila de matrices
          pushMatrix();
      scale(-1,1);
      // El segundo y tercer parámetro le indican a la imagen las coordenadas por defecto de la imagen.
      image(camara.get(),-width,0);
      popMatrix();
     
        camara.loadPixels();

        float promedioXMarcadorA = 0;
        float promedioYMarcadorA = 0;

        int cantidadPixelesCoincidenConMarcadorA = 0;
        //empieza a recorrer cada pixel
        for ( int x = 0; x < camara.width; x++ )
        {
            for ( int y = 0; y < camara.height; y++ )
            {
                color pixelActual = camara.pixels[x + y * camara.width];

                float cantidadRojoDelPixelActual = red(pixelActual);
                float cantidadVerdeDelPixelActual = green(pixelActual);
                float cantidadAzulDelPixelActual = blue(pixelActual);

                float cantidadRojoDelMarcadorA = red(marcadorA);
                float cantidadVerdeDelMarcadorA = green(marcadorA);
                float cantidadAzulDelMarcadorA = blue(marcadorA);

                // Calculando la distancia de similitud en "color" para el marcador A.
                float similitudEnDistanciaDelColorMarcadorA = dist(cantidadRojoDelPixelActual, cantidadVerdeDelPixelActual, cantidadAzulDelPixelActual, cantidadRojoDelMarcadorA, cantidadVerdeDelMarcadorA, cantidadAzulDelMarcadorA); // We are using the dist( ) function to compare the current color with the color we are tracking.
                
                // Esta muy cerca del rojo
                if (similitudEnDistanciaDelColorMarcadorA < semejanzaEnColor)
                {
                    promedioXMarcadorA += x;
                    promedioYMarcadorA += y;
                    cantidadPixelesCoincidenConMarcadorA++;
                }
            }
        }

        if ( cantidadPixelesCoincidenConMarcadorA > minimoDePixelesSemejantes )
        {
            xMarcadorA = (int) promedioXMarcadorA / cantidadPixelesCoincidenConMarcadorA;
            yMarcadorA = (int) promedioYMarcadorA / cantidadPixelesCoincidenConMarcadorA;
            print("xMarcadorA antes: ",xMarcadorA,"\n");
            xMarcadorA = 640-xMarcadorA;
            print("xMarcadorA DESPUÉS DEL MIRROR: ",xMarcadorA,"\n");
        }
        //print("VALORES: ",xMarcadorA+","+yMarcadorA+"\n");
        
        dibujarCentroide(marcadorA, xMarcadorA, yMarcadorA);

        if (xMarcadorA > 0 || yMarcadorA > 0) {
            datosPosiciones = (width-xMarcadorA)+","+(height-yMarcadorA)+"\n";
            //print(datosPosiciones);
        } else {
            datosPosiciones = "0,0,0,0\n";
        }
        //Enviar el dato por el puerto
        servidor.write(datosPosiciones);
    }
}

/**
* Dibujar centroide.
*/
void dibujarCentroide (color marcador, int xMarcador, int yMarcador) {
    fill(marcador);
    strokeWeight(4.0);
    stroke(0);
    ellipse(xMarcador, yMarcador, 16, 16);
}

void mousePressed() {

    int loc = mouseX + mouseY * camara.width;
    color pixelLeido = camara.pixels[loc];
    print("X: ", mouseX, "Y: ", mouseY, " loc: ",loc ,"pixelLeido: ",pixelLeido,"\n");
}
