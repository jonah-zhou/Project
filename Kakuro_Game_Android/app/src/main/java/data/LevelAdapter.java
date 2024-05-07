package data;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.kakuro_game_android.GamePlayActivity;
import com.example.kakuro_game_android.R;
import com.example.kakuro_game_android.RankActivity;

import java.util.ArrayList;

import model.GamePlay;
import model.Level;

public class LevelAdapter extends BaseAdapter {
    private Context context;

    private ArrayList<Level> levelList;


    public LevelAdapter(Context context, ArrayList<Level> levelList){
        this.context = context;
        this.levelList = levelList;
    }

    @Override
    public int getCount() {
        return levelList.size();
    }

    @Override
    public Object getItem(int position) {
        return levelList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View oneItem = null;
        TextView tvLevelId, tvLevelDescription;
        Button viewRankButton, playGameButton;

        LayoutInflater inflater = LayoutInflater.from(context);
        oneItem = inflater.inflate(R.layout.level_item, (ViewGroup) convertView,false);

        tvLevelId = oneItem.findViewById(R.id.item_name);
        tvLevelDescription = oneItem.findViewById(R.id.item_description);
        viewRankButton = oneItem.findViewById(R.id.button_view_rank);
        playGameButton = oneItem.findViewById(R.id.button_play_game);
        final Level oneLevel = (Level) getItem(position);
        tvLevelId.setText(String.valueOf(oneLevel.getLevelId()));
        tvLevelDescription.setText(oneLevel.getDescription());
        playGameButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    GamePlay.startNewGame(oneLevel.getLevelId(), new GamePlay.LoadGameListener() {
                        @Override
                        public void onLoadGameSuccess(GamePlay playGame) {
                            Intent intent = new Intent(parent.getContext(), GamePlayActivity.class);
                            intent.putExtra("gamePlay", playGame);
                            parent.getContext().startActivity(intent);
                        }
                        @Override
                        public void onLoadGameFailed(String message) {
                            Toast.makeText(parent.getContext(), "Cannot Start Game", Toast.LENGTH_SHORT).show();
                        }
                    });
            }
        });
        viewRankButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(parent.getContext(), RankActivity.class);
                intent.putExtra("receivedLevelId", oneLevel.getLevelId());
                parent.getContext().startActivity(intent);
            }
        });

        return oneItem;
    }
}
