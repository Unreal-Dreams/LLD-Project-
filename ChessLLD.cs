#include<bits/stdc++.h>
using namespace std;
typedef long long ll;
typedef vector<long long> v;
#define fr first 
#define sc second 
typedef pair<long long,long long> pll;
typedef vector<int> vi;
#define rep(i,a,b) for(int i=a;i<b;i++)

static Position{
    int row,column;
    Position(int r,int c):row(r),col(c){}
}

class Peice{
    protected: 
    bool isWhite;
    
    public:
    Peice (bool white):isWhite(white){
    
    }
    
    virtual ~Peice();
    virtural bool isValid(Position start,Position end, Peice* board[8][8])=0 //Forces child to implement it
}

void Board:: initialize(){
    //Initialzie pawn on 2nd and 7th row
    for(int j=0;j<8;j++){
        chessBoard[1][j]=new Pawn(true);  //White pawn
        chessBoard[6][j]=new Pawn(false); //Black pawn
    }
    
    //Initialize rook 
    
}

void Board::isKingInCheck(Position start,Position end,Postition* chessBoard[8][8]){
     
    //Make the move don't be afraid. 
    bool isWhitePeice= chessBoard[start.row][start.column]->isWhite;
    Peices* temp=chessBoard[end.row][end.column];
    chessBoard[end.row][end.column] = chessBoard[start.row][start.column];
    
    //Get King's current position
    Position kingPos(-1,-1);
    for(int i=0;i<8;i++){
        for(int j=0;j<8;j++){
            if(chessBoard[i][j] != nullptr && dynamic_cast<King*>(chessBoard[i][j]) && chessBoard[i][j]->isWhite == isWhitePeice){
                kingPos=Position(i,j);
                break;
            }
        }
    }
    
    //Now check all the black peiecs and see if they can move to kingPos
    
    for(int i=0;i<8;i++){
        for(int j=0;j<8;j++){
            if(chessBoard[i][j] != nullptr and chessBoard[i][j]->isWhite == !isWhitePeice){
                Position startPos(i,j);
                if(chessBoard[i][j]->isValid(startPos,kingPos,chessBoard)) return true;
            }
        }
    }
    
    chessBoard[start.row][start.column] = chessBoard[end.row][end.column];
    chessBoard[end.row][end.column] = temp;
}

class Board{
    Peices* chessBoard[8][8];
    
    Board(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                chessBoard[i][j]==nullptr;
            }
        }
    }
    
    void initialize();
    void move(Position start,Position end);
    void isKingInCheck(Position start,Position end,Postition* chessBoard[8][8]);
    
}



class Pawn:public Peice{
    
    Pawn (bool white):Peice(white){};
    
    
    
    bool isValid(Position start,Position end, Peice* board[8][8]) override{
        int direction = (isWhite)?1:-1;
        int startRow  = (isWhite)?1:6;
        // 1 move 
        if(end.row == start.row+direction && end.column == start.column){
            return board[end.row][end.column] == nullptr;
        }
        
        
        // 2 moves
        if(start.row == startRow && end.row == start.row+2*direction && end.column == start.column){
            return board[end.row][end.column] == nullptr
        }
        
        //capture
            //normal capture
            // emphssant capture
            
        //Is bringing own king into check 

    }
    
    
}

class King:public Peice{
    
}

class Queen:public Peice{
    
}

class Rook:public Peice{
    
}

class Bishop:public Peice{
    
}


class Knight:public Peice{
    
}



int main() {
	// your code goes here
	
	return 0;
}
